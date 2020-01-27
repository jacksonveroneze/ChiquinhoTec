using GraphQL.Language.AST;
using GraphQL.Types;

namespace ChiquinhoTec.GerenciadorContratacao.Graphql.ScalarTypes
{
    //
    // Summary:
    //     /// Class responsible for mapping schema. ///
    //
    public class EmailGraphType : ScalarGraphType
    {
        public EmailGraphType() => Name = "Email";

        public override object Serialize(object value)
        {
            return value;
        }

        public override object ParseValue(object value)
        {
            return value?.ToString();
        }

        public override object ParseLiteral(IValue value)
        {
            var stringValue = value as StringValue;
            return stringValue?.Value;
        }
    }
}