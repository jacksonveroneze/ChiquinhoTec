using ChiquinhoTec.GerenciadorContratacao.Domain.Commands;
using ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Repositories;
using ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Services;
using ChiquinhoTec.GerenciadorContratacao.Graphql.ScalarTypes;
using ChiquinhoTec.GerenciadorContratacao.Graphql.Schema;
using ChiquinhoTec.GerenciadorContratacao.Graphql.Schema.PersonSchema;
using ChiquinhoTec.GerenciadorContratacao.Infra.Data.Repositories;
using ChiquinhoTec.GerenciadorContratacao.Services;
using ChiquinhoTec.GerenciadorContratacao.Services.Validators;
using FluentValidation;
using GraphQL;
using GraphQL.DataLoader;
using GraphQL.Http;
using GraphQL.Types;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GraphqlSchemaApplication = ChiquinhoTec.GerenciadorContratacao.Graphql.Schema;

namespace ChiquinhoTec.GerenciadorContratacao.IoC
{
    public class InjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration Configuration)
        {
            //
            // Inject Services
            //
            services.AddTransient<IAddressService, AddressService>();
            services.AddTransient<IInterviewService, InterviewService>();
            services.AddTransient<IPersonService, PersonService>();
            services.AddTransient<IEntityAuditService, EntityAuditService>();
            //
            // Inject Repositories
            //
            services.AddTransient<IAddressRepository, AddressRepository>();
            services.AddTransient<IInterviewRepository, InterviewRepository>();
            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddTransient<IEntityAuditRepository, EntityAuditRepository>();
            //
            // Inject Validators
            //
            services.AddTransient<IValidator<AddressCommand>>(x => new AddressValidator(x.GetRequiredService<IPersonRepository>()));
            services.AddTransient<IValidator<InterviewCommand>>(x => new InterviewValidator(x.GetRequiredService<IPersonRepository>(), x.GetRequiredService<IInterviewRepository>()));
            services.AddTransient<IValidator<PersonCommand>>(x => new PersonValidator(x.GetRequiredService<IPersonRepository>()));
            //
            // GraphQL - Schema
            //
            services.AddSingleton<QueryType>();
            services.AddSingleton<MutationType>();
            //
            services.AddTransient<PersonMutationType>();
            services.AddTransient<PersonQueryType>();
            services.AddSingleton<PersonType>();
            services.AddSingleton<PersonInputType>();
            //
            services.AddSingleton<EmailGraphType>();
            services.AddSingleton<CpfGraphType>();
            //
            // GraphQL - Structure
            //
            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));

            services.AddSingleton<IDocumentWriter, DocumentWriter>();
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<DataLoaderDocumentListener>();
            services.AddSingleton<DataLoaderContext>();
            services.AddSingleton<IDataLoaderContextAccessor>(new DataLoaderContextAccessor());
            services.AddSingleton<ISchema>(new GraphqlSchemaApplication.Schema(new FuncDependencyResolver(type => services.BuildServiceProvider().GetService(type))));
        }
    }
}