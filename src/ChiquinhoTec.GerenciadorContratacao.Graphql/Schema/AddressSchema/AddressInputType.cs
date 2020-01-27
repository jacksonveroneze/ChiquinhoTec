using GraphQL.Types;
namespace ChiquinhoTec.GerenciadorContratacao.Graphql.Schema.AddressSchema
{
    //
    // Summary:
    //     /// Class responsible for mapping schema. ///
    //
    public class AddressInputType : InputObjectGraphType
    {
        //
        // Summary:
        //     /// Method responsible for initializing the schema. ///
        //
        public AddressInputType()
        {
            Name = "AddressInput";
            Description = "Address Input Type";

            Field<NonNullGraphType<StringGraphType>>("postalCode");
            Field<NonNullGraphType<StringGraphType>>("state");
            Field<NonNullGraphType<StringGraphType>>("city");
            Field<NonNullGraphType<StringGraphType>>("district");
            Field<NonNullGraphType<StringGraphType>>("street");
            Field<NonNullGraphType<IntGraphType>>("streetNumber");
            Field<NonNullGraphType<StringGraphType>>("complement");
            Field<NonNullGraphType<BooleanGraphType>>("primaryAddress");
            Field<NonNullGraphType<IdGraphType>>("person");
        }
    }
}