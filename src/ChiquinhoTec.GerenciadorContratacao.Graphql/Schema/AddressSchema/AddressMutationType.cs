using ChiquinhoTec.GerenciadorContratacao.Register.Domain.Commands;
using ChiquinhoTec.GerenciadorContratacao.Register.Domain.Entities;
using ChiquinhoTec.GerenciadorContratacao.Register.Domain.Interfaces.Services;
using GraphQL;
using GraphQL.Types;
using System;
using System.Linq;

namespace ChiquinhoTec.GerenciadorContratacao.Graphql.Schema.AddressSchema
{
    //
    // Summary:
    //     /// Class responsible for mapping schema. ///
    //
    public class AddressMutationType : ObjectGraphType
    {
        //
        // Summary:
        //     /// Method responsible for initializing the schema. ///
        //
        // Parameters:
        //   addressService:
        //     The addressService param.
        //
        public AddressMutationType(IAddressService addressService)
        {
            Name = "AddressMutation";
            Description = "Address Mutation Type";

            FieldAsync<AddressType>(
                name: "createAddress",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<AddressInputType>> { Name = "data" }
                ),
                resolve: async context =>
                {
                    AddressCommand data = context.GetArgument<AddressCommand>("data");

                    Address result = await addressService.AddAsync(data);

                    if (addressService.ValidationResult().IsValid is true)
                        return result;

                    context.Errors.AddRange(addressService.ValidationResult().Errors.Select(x => new ExecutionError(x.ErrorMessage)));

                    return null;
                }
            );

            FieldAsync<BooleanGraphType>(
                name: "removeAddress",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }
                ),
                resolve: async context =>
                {
                    Guid id = context.GetArgument<Guid>("id");

                    await addressService.RemoveAsync(id);

                    if (addressService.ValidationResult().IsValid is true)
                        return true;

                    context.Errors.AddRange(addressService.ValidationResult().Errors.Select(x => new ExecutionError(x.ErrorMessage)));

                    return null;
                }
            );
        }
    }
}