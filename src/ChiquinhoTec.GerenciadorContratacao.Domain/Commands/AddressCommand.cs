using System;

namespace ChiquinhoTec.GerenciadorContratacao.Domain.Entities
{
    //
    // Summary:
    //     /// Class responsible for the command. ///
    //
    public class AddressCommand : BaseCommand
    {
        public Guid Id { get; set; }

        public string PostalCode { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string District { get; set; }

        public string Address { get; set; }

        public int AddressNumber { get; set; }

        public string Complement { get; set; }

        public bool PrimaryAddress { get; set; }

        public Guid PersonId { get; set; }
    }
}