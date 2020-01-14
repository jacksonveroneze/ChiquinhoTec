using System;

namespace ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Services
{
    //
    // Summary:
    //     /// Interface responsible for contrat. ///
    //
    public class IInterviewService : IBaseService
    {
        Task<Interview> AddAsync(InterviewCommand command);

        Task RemoveAsync(Guid id);

        Task<Interview> UpdateAsync(InterviewCommand command, Guid id);
    }
}