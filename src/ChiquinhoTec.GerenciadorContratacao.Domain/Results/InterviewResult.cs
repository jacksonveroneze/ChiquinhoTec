using System;
using ChiquinhoTec.GerenciadorContratacao.Common;
using ChiquinhoTec.GerenciadorContratacao.Domain.Enums;

namespace ChiquinhoTec.GerenciadorContratacao.Domain.Results
{
    //
    // Summary:
    //     /// Class responsible for the command. ///
    //
    public class InterviewResult : BaseResult
    {
        public Guid Id { get; set; }

        public DateTime SchedulingDate { get; set; }

        public Squads Squad { get; set; }

        public Guid PersonId { get; set; }
    }
}