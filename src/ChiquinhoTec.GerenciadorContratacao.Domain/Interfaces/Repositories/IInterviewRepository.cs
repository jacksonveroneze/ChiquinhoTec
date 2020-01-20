using ChiquinhoTec.GerenciadorContratacao.Common;
using ChiquinhoTec.GerenciadorContratacao.Domain.Commands;
using ChiquinhoTec.GerenciadorContratacao.Domain.Entities;
using ChiquinhoTec.GerenciadorContratacao.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Repositories
{
    //
    // Summary:
    //     /// Interface responsible for contrat. ///
    //
    public interface IInterviewRepository : IBaseRepository<Interview> 
    {
        Task<List<Interview>> FindByFilterAsync(InterviewFilterCommand command);

        Task<List<Interview>> FindInterviewsByPersonId(Guid personId);

        bool HasInterviewsByPersonId(Guid personId);

        Task<Interview> FindInterviewCurrentYearByPersonIdAndSquad(Guid personId, Squads squadId);

        Task<Interview> FindInterviewByPersonIdAndDate(Guid personId, DateTime date);

        Task<Interview> FindInterviewBySquadAndDate(Squads squadId, DateTime date);
    }
}
