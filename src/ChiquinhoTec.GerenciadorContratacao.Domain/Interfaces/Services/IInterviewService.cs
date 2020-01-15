using System;
using System.Threading.Tasks;
using ChiquinhoTec.GerenciadorContratacao.Common;
using ChiquinhoTec.GerenciadorContratacao.Domain.Entities;

namespace ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Services
{
    //
    // Summary:
    //     /// Interface responsible for contrat. ///
    //
    public interface IInterviewService : IBaseService
    {
        Task<Interview> AddAsync(InterviewCommand command);

        Task RemoveAsync(Guid id);

        Task<Interview> UpdateAsync(InterviewCommand command, Guid id);
    }
}