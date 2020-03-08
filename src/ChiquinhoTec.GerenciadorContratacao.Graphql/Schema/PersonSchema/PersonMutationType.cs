using GraphQL;
using GraphQL.Types;
using System;
using System.Linq;
using ChiquinhoTec.GerenciadorContratacao.Register.Domain.Commands;
using ChiquinhoTec.GerenciadorContratacao.Register.Domain.Entities;
using ChiquinhoTec.GerenciadorContratacao.Register.Domain.Interfaces.Services;

namespace ChiquinhoTec.GerenciadorContratacao.Graphql.Schema.PersonSchema
{
    //
    // Summary:
    //     /// Class responsible for mapping schema. ///
    //
    public class PersonMutationType : ObjectGraphType
    {
        //
        // Summary:
        //     /// Method responsible for initializing the schema. ///
        //
        // Parameters:
        //   personService:
        //     The personService param.
        //
        public PersonMutationType(IPersonService personService)
        {
            Name = "UserMutation";
            Description = "User Mutation Type";

            FieldAsync<PersonType>(
                name: "createPerson",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<PersonInputType>> { Name = "data" }
                ),
                resolve: async context =>
                {
                    PersonCommand data = context.GetArgument<PersonCommand>("data");

                    Person result = await personService.AddAsync(data);

                    if (personService.ValidationResult().IsValid is true)
                        return result;

                    context.Errors.AddRange(personService.ValidationResult().Errors.Select(x => new ExecutionError(x.ErrorMessage)));

                    return null;
                }
            );

            FieldAsync<BooleanGraphType>(
                name: "removePerson",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }
                ),
                resolve: async context =>
                {
                    Guid id = context.GetArgument<Guid>("id");

                    await personService.RemoveAsync(id);

                    if (personService.ValidationResult().IsValid is true)
                        return true;

                    context.Errors.AddRange(personService.ValidationResult().Errors.Select(x => new ExecutionError(x.ErrorMessage)));

                    return null;
                }
            );
        }
    }
}