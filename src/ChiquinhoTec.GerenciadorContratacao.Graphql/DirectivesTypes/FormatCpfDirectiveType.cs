using GraphQL.Types;
using System.Collections.Generic;

namespace ChiquinhoTec.GerenciadorContratacao.Graphql.DirectivesTypes
{
    //
    // Summary:
    //     /// Class responsible for mapping schema. ///
    //
    public class FormatCpfDirectiveType : DirectiveGraphType
    {
        public FormatCpfDirectiveType() : base("formatCpf", new List<DirectiveLocation>()
        {
            DirectiveLocation.Field,
            DirectiveLocation.FragmentSpread,
            DirectiveLocation.InlineFragment,
        })
        {
            Description = "Format CPF. Ex: XXX.XXX.XXX-XX.";
        }
    }
}