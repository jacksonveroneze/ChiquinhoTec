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
        }
    }
}