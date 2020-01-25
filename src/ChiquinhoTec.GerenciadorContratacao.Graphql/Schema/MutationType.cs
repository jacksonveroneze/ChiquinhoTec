using ChiquinhoTec.GerenciadorContratacao.Graphql.Schema.AddressSchema;
using ChiquinhoTec.GerenciadorContratacao.Graphql.Schema.InterviewSchema;
using ChiquinhoTec.GerenciadorContratacao.Graphql.Schema.PersonSchema;
using GraphQL.Types;

namespace ChiquinhoTec.GerenciadorContratacao.Graphql.Schema
{
    //
    // Summary:
    //     /// Class responsible for mapping schema. ///
    //
    public class MutationType : ObjectGraphType
    {
        //
        // Summary:
        //     /// Method responsible for initializing the schema. ///
        //
        public MutationType()
        {
            Name = "Mutation";
            Field<AddressMutationType>("addressMutationType", resolve: context => new { });
            Field<InterviewMutationType>("interviewMutationType", resolve: context => new { });
            Field<PersonMutationType>("personMutationType", resolve: context => new { });
        }
    }
}