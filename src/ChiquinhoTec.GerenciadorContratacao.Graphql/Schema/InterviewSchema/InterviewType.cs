using ChiquinhoTec.GerenciadorContratacao.Domain.Entities;
using ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Repositories;
using ChiquinhoTec.GerenciadorContratacao.Graphql.Schema.PersonSchema;
using GraphQL.DataLoader;
using GraphQL.Types;
using System;

namespace ChiquinhoTec.GerenciadorContratacao.Graphql.Schema.InterviewSchema
{
    //
    // Summary:
    //     /// Class responsible for mapping schema. ///
    //
    public class InterviewType : ObjectGraphType<Interview>
    {
        //
        // Summary:
        //     /// Method responsible for initializing the schema. ///
        //
        // Parameters:
        //   personRepository:
        //     The personRepository param.
        //
        //   accessor:
        //     The accessor param.
        //
        public InterviewType(IPersonRepository personRepository, IDataLoaderContextAccessor accessor)
        {
            Name = " Interview";
            Description = " Interview Type";

            Field(x => x.Id, type: typeof(IdGraphType));
            Field(x => x.SchedulingDate, type: typeof(StringGraphType));
            Field(x => x.Squad, type: typeof(StringGraphType));
            Field(x => x.CreatedAt, type: typeof(StringGraphType));
            Field(x => x.UpdatedAt, type: typeof(StringGraphType));
            Field(x => x.IsActive);
            Field(x => x.Version);

            Field<PersonType, Person>()
                .Name("person")
                .ResolveAsync(context =>
                {
                    IDataLoader<Guid, Person> customersLoader = accessor.Context
                        .GetOrAddBatchLoader<Guid, Person>("PersonById", personRepository.FindPersonsByIdAsync);

                    return customersLoader.LoadAsync(context.Source.Person.Id);
                });
        }
    }
}