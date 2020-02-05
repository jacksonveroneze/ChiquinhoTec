using GraphQL.Types;
namespace ChiquinhoTec.GerenciadorContratacao.Graphql.Schema.InterviewSchema
{
    //
    // Summary:
    //     /// Class responsible for mapping schema. ///
    //
    public class InterviewInputType : InputObjectGraphType
    {
        //
        // Summary:
        //     /// Method responsible for initializing the schema. ///
        //
        public InterviewInputType()
        {
            Name = "InterviewInput";
            Description = "Interview Input Type";

            Field<NonNullGraphType<DateTimeGraphType>>("schedulingDate");
            Field<NonNullGraphType<StringGraphType>>("squad");
            Field<NonNullGraphType<IdGraphType>>("personId");
        }
    }
}