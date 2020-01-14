using System;

namespace ChiquinhoTec.GerenciadorContratacao.Domain.Entities
{
    //
    // Summary:
    //     /// Class responsible for the entity. ///
    //    
    public class Person : BaseEntity
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        public string Name { get; private set; }

        public DateTime BirthDate { get; private set; }

        public Cpf Cpf { get; private set; }

        public string Phone { get; private set; }

        public Email Email { get; private set; }

        public string Profile { get; private set; }

        public string ProfessionalDescription { get; private set; }

        public virtual IEnumerable<Address> Adresses { get; private set; } = new List<Address>();

        public virtual IEnumerable<Interview> Interviews { get; private set; } = new List<Interview>();
    }
}