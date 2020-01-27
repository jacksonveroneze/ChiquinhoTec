using GraphQL.Instrumentation;
using GraphQL.Language.AST;
using GraphQL.Types;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChiquinhoTec.GerenciadorContratacao.Graphql.FieldsMiddleware
{
    //
    // Summary:
    //     /// Class responsible for mapping schema. ///
    //
    public class DefaultFieldMiddleware
    {
        public async Task<object> Resolve(ResolveFieldContext context, FieldMiddlewareDelegate next)
        {
            Object result = await next(context);

            if (result is null)
                return result;

            Directives directives = context.FieldAst.Directives;

            if (directives.Find("lowerCase") != null)
                return result.ToString().ToLowerInvariant();

            if (directives.Find("upperCase") != null)
                return result.ToString().ToUpperInvariant();

            if (directives.Find("formatCpf") != null)
            {
                string entryText = Regex.Replace(result.ToString(), @"\D", "");

                entryText = Regex.Replace(entryText, @"(\d{3})(\d{0,3})(\d{0,3})(\d{0,3})", @"$1.$2.$3-$4");

                return entryText;
            }

            if (directives.Find("formatPostalCode") != null)
            {
                string entryText = result.ToString();

                return Regex.Replace(entryText, @"(\d{5})(\d{3})", @"$1-$2");
            }

            if (directives.Find("formatDateTime") != null)
            {
                Directive formatDateTime = directives.Find("formatDateTime");

                string format = formatDateTime.Arguments.ValueFor("format").Value.ToString();

                DateTime datetime = (DateTime)result;

                return datetime.ToString(format);
            }

            return result;
        }
    }
}