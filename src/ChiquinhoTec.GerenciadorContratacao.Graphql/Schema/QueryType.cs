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
    public class QueryType : ObjectGraphType
    {
        //
        // Summary:
        //     /// Method responsible for initializing the schema. ///
        //
        public QueryType()
        {
            Name = "Query";
            Field<AddressQueryType>("AddressRootQuery", resolve: context => new { });
            Field<InterviewQueryType>("InterviewRootQuery", resolve: context => new { });
            Field<PersonQueryType>("personRootQuery", resolve: context => new { });
        }
    }
}