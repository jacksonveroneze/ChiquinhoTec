using System;
using ChiquinhoTec.GerenciadorContratacao.Common;

namespace ChiquinhoTec.GerenciadorContratacao.Register.Domain.Commands
{
    //
    // Summary:
    //     /// Class responsible for the command. ///
    //
    public class AddressCommand : BaseCommand
    {
        public Guid? Id { get; set; }

        public string PostalCode { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string District { get; set; }

        public string Street { get; set; }

        public int StreetNumber { get; set; }

        public string Complement { get; set; }

        public bool PrimaryAddress { get; set; }

        public Guid PersonId { get; set; }
    }
}