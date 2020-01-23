using ChiquinhoTec.GerenciadorContratacao.Graphql.ScalarTypes;
using GraphQL.Types;
namespace ChiquinhoTec.GerenciadorContratacao.Graphql.Schema.PersonSchema
{
    //
    // Summary:
    //     /// Class responsible for mapping schema. ///
    //
    public class PersonInputType : InputObjectGraphType
    {
        //
        // Summary:
        //     /// Method responsible for initializing the schema. ///
        //
        public PersonInputType()
        {
            Name = "PersonInput";
            Description = "Person Input Type";

            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<DateTimeGraphType>>("birthDate");
            Field<NonNullGraphType<CpfGraphType>>("cpf");
            Field<NonNullGraphType<StringGraphType>>("phone");
            Field<NonNullGraphType<EmailGraphType>>("email");
            Field<NonNullGraphType<StringGraphType>>("profile");
            Field<NonNullGraphType<StringGraphType>>("professionalDescription");
        }
    }
}