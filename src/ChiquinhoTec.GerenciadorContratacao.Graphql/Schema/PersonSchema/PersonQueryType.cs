using ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Repositories;
using GraphQL.Types;
using System;

namespace ChiquinhoTec.GerenciadorContratacao.Graphql.Schema.PersonSchema
{
    //
    // Summary:
    //     /// Class responsible for mapping schema. ///
    //
    public class PersonQueryType : ObjectGraphType
    {
        //
        // Summary:
        //     /// Method responsible for initializing the schema. ///
        //
        // Parameters:
        //   personRepository:
        //     The personRepository param.
        //
        public PersonQueryType(IPersonRepository personRepository)
        {
            Name = "PersonQuery";
            Description = "Person Query Type";

            Field<ListGraphType<PersonType>>(
                name: "allPersons",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "skip" },
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "take" }
                ),
                resolve: context => personRepository.FindAllAsync());

            Field<PersonType>(
                name: "Person",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }
                ),
                resolve: context => personRepository.FindAsync(context.GetArgument<Guid>("id")));
        }
    }
}