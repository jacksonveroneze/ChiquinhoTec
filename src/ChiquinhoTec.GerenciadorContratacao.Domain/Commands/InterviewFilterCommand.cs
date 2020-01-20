using ChiquinhoTec.GerenciadorContratacao.Common;
using ChiquinhoTec.GerenciadorContratacao.Domain.Enums;
using System;

namespace ChiquinhoTec.GerenciadorContratacao.Domain.Commands
{
    //
    // Summary:
    //     /// Class responsible for the command. ///
    //
    public class InterviewFilterCommand : BaseCommand
    {
        public string PersonName { get; set; }

        public string PersonCpf { get; set; }

        public Squads Squad { get; set; }

        public DateTime? SchedulingDate { get; set; }

        public string Email { get; set; }
    }
}