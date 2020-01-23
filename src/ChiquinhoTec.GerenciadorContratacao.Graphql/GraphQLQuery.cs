using Newtonsoft.Json.Linq;

namespace ChiquinhoTec.GerenciadorContratacao.Graphql
{
    //
    // Summary:
    //     /// Class responsible for mapping schema. ///
    //
    public class GraphQLQuery
    {
        public string OperationName { get; set; }

        public string NamedQuery { get; set; }

        public string Query { get; set; }

        public JObject Variables { get; set; }
    }
}