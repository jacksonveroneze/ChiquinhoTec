using System;
using ChiquinhoTec.GerenciadorContratacao.Common;

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

        public string State { get; private set; }

        public string City { get; private set; }

        public string District { get; private set; }

        public string Street { get; private set; }

        public int StreetNumber { get; private set; }

        public string Complement { get; private set; }

        public bool PrimaryAddress { get; private set; }

        public Person Person { get; private set; }
    }
}