using System;

namespace ChiquinhoTec.GerenciadorContratacao.Domain.Entities
{
    //
    // Summary:
    //     /// Class responsible for the entity. ///
    //
    public class Address : BaseEntity
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        public string PostalCode { get; private set; }

        public string Estado { get; private set; }

        public string City { get; private set; }

        public string Bairro { get; private set; }

        public string Address { get; private set; }

        public int Number { get; private set; }

        public string Complemento { get; private set; }

        public bool EnderecoPrincipal { get; private set; }

        public Person Person { get; private set; }
    }
}