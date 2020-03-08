using ChiquinhoTec.GerenciadorContratacao.Register.Domain.Interfaces.Repositories;
using GraphQL.Types;
using System;

namespace ChiquinhoTec.GerenciadorContratacao.Graphql.Schema.AddressSchema
{
    //
    // Summary:
    //     /// Class responsible for mapping schema. ///
    //
    public class AddressQueryType : ObjectGraphType
    {
        //
        // Summary:
        //     /// Method responsible for initializing the schema. ///
        //
        // Parameters:
        //   addressRepository:
        //     The addressRepository param.
        //
        public AddressQueryType(IAddressRepository addressRepository)
        {
            Name = "AddressQuery";
            Description = "Address Query Type";

            Field<ListGraphType<AddressType>>(
                name: "allAddress",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "skip" },
                    new QueryArgument<IntGraphType> { Name = "take" }
                ),
                resolve: context => addressRepository.FindAllAsync());

            Field<AddressType>(
                name: "Address",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }
                ),
                resolve: context => addressRepository.FindAsync(context.GetArgument<Guid>("id")));
        }
    }
}