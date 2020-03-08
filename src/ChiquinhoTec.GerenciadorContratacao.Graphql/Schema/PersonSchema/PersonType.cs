using ChiquinhoTec.GerenciadorContratacao.Register.Domain.Entities;
using GraphQL.Types;

namespace ChiquinhoTec.GerenciadorContratacao.Graphql.Schema.PersonSchema
{
    //
    // Summary:
    //     /// Class responsible for mapping schema. ///
    //
    public class PersonType : ObjectGraphType<Person>
    {
        //
        // Summary:
        //     /// Method responsible for initializing the schema. ///
        //
        public PersonType()
        {
            Name = "Person";
            Description = "Person Type";

            Field(x => x.Id, type: typeof(IdGraphType));
            Field(x => x.Name).Name("name");
            Field(x => x.BirthDate, type: typeof(StringGraphType));
            Field(x => x.Cpf.Value).Name("cpf");
            Field(x => x.Phone);
            Field(x => x.Email.Value).Name("email");
            Field(x => x.Profile);
            Field(x => x.ProfessionalDescription);
            Field(x => x.CreatedAt, type: typeof(StringGraphType));
            Field(x => x.UpdatedAt, type: typeof(StringGraphType));
            Field(x => x.Version);
            Field(x => x.IsActive);
        }
    }
}