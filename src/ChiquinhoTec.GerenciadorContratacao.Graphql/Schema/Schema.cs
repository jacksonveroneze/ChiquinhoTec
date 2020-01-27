using ChiquinhoTec.GerenciadorContratacao.Graphql.DirectivesTypes;
using GraphQL;
using TypesGraphQL = GraphQL.Types;

namespace ChiquinhoTec.GerenciadorContratacao.Graphql.Schema
{
    //
    // Summary:
    //     /// Class responsible for mapping schema. ///
    //
    public class Schema : TypesGraphQL.Schema
    {
        //
        // Summary:
        //     /// Method responsible for initializing the schema. ///
        //
        // Parameters:
        //   resolver:
        //     The resolver param.
        //
        public Schema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<QueryType>();
            Mutation = resolver.Resolve<MutationType>();

            RegisterDirective(new FormatCpfDirectiveType());
        }
    }
}