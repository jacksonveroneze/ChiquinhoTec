using ChiquinhoTec.GerenciadorContratacao.Graphql;
using ChiquinhoTec.GerenciadorContratacao.Graphql.FieldsMiddleware;
using GraphQL;
using GraphQL.DataLoader;
using GraphQL.Http;
using GraphQL.Types;
using GraphQL.Validation;
using GraphQL.Validation.Complexity;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ChiquinhoTec.GerenciadorContratacao.Api.Middlewares
{
    //
    // Summary:
    //     /// Middleware responsible for carrying out the operations. ///
    //
    public class GraphQLMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IDocumentWriter _documentWriter;
        private readonly IDocumentExecuter _documentExecutor;
        private readonly IEnumerable<IValidationRule> _validationRules;

        //
        // Summary:
        //     /// Method responsible for initializing the middleware. ///
        //
        // Parameters:
        //   next:
        //     The next param.
        //
        //   documentWriter:
        //     The documentWriter param.
        //
        //   documentExecutor:
        //     The documentExecutor param.
        //
        public GraphQLMiddleware(RequestDelegate next, IDocumentWriter documentWriter, IDocumentExecuter documentExecutor, IEnumerable<IValidationRule> validationRules)
        {
            _next = next;
            _documentWriter = documentWriter;
            _documentExecutor = documentExecutor;
            _validationRules = validationRules;
        }

        //
        // Summary:
        //     /// Method responsible for run the middleware. ///
        //
        // Parameters:
        //   httpContext:
        //     The httpContext param.
        //
        //   schema:
        //     The schema param.
        //
        //   serviceProvider:
        //     The serviceProvider param.
        //
        public async Task InvokeAsync(HttpContext httpContext, ISchema schema, IServiceProvider serviceProvider)
        {
            if (!(httpContext.Request.Path.StartsWithSegments("/graphqlapi") &&
                    string.Equals(httpContext.Request.Method, "POST", StringComparison.OrdinalIgnoreCase)))
                await _next(httpContext);

            using (StreamReader streamReader = new StreamReader(httpContext.Request.Body))
            {
                string body = await streamReader.ReadToEndAsync();

                GraphQLQuery request = JsonConvert.DeserializeObject<GraphQLQuery>(body);

                DateTime start = DateTime.UtcNow;

                ExecutionResult result = await _documentExecutor.ExecuteAsync(x =>
                {
                    x.Schema = schema;
                    x.Query = request.Query;
                    x.Inputs = request.Variables.ToInputs();
                    x.Listeners.Add(serviceProvider.GetRequiredService<DataLoaderDocumentListener>());
                    x.ExposeExceptions = false;
                    x.ComplexityConfiguration = new ComplexityConfiguration { MaxDepth = 15 };
                    //x.FieldMiddleware.Use<DefaultFieldMiddleware>();
                    x.ValidationRules = DocumentValidator.CoreRules().Concat(_validationRules).ToList();
                }).ConfigureAwait(false);

                string json = await _documentWriter.WriteToStringAsync(result);

                await httpContext.Response.WriteAsync(json);
            }
        }
    }
}