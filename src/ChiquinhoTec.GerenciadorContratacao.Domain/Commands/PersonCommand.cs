using System;
using ChiquinhoTec.GerenciadorContratacao.Common;

namespace ChiquinhoTec.GerenciadorContratacao.Domain.Entities
{
    //
    // Summary:
    //     /// Class responsible for the command. ///
    //
    public class PersonCommand : BaseCommand
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public string Cpf { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Profile { get; set; }

        public string ProfessionalDescription { get; set; }
    }
}