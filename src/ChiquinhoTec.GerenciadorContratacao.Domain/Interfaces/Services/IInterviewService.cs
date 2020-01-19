using ChiquinhoTec.GerenciadorContratacao.Common;
using ChiquinhoTec.GerenciadorContratacao.Domain.Commands;
using ChiquinhoTec.GerenciadorContratacao.Domain.Entities;
using ChiquinhoTec.GerenciadorContratacao.Domain.Results;
using System;
using System.Threading.Tasks;

namespace ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Services
{
    //
    // Summary:
    //     /// Interface responsible for contrat. ///
    //
    public interface IInterviewService : IBaseService
    {
        Task<Interview> AddAsync(InterviewCommand command);

        Task<bool> RemoveAsync(Guid id);

        Task<Interview> UpdateAsync(InterviewCommand command, Guid id);
    }
}