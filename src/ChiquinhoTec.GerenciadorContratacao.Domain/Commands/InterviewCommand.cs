using System;
using ChiquinhoTec.GerenciadorContratacao.Common;

namespace ChiquinhoTec.GerenciadorContratacao.Domain.Entities
{
    //
    // Summary:
    //     /// Class responsible for the command. ///
    //
    public class InterviewCommand : BaseCommand
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public TimeSpan Schedule { get; set; }

        public string Squad { get; set; }

        public Guid PersonId { get; set; }
    }
}