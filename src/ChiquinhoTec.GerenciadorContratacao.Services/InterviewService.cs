using System;
using System.Threading.Tasks;
using ChiquinhoTec.GerenciadorContratacao.Domain.Entities;
using ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Repositories;
using ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Services;

namespace ChiquinhoTec.GerenciadorContratacao.Services
{
    //
    // Summary:
    //     /// Class responsible for the service. ///
    //
    public class InterviewService : IInterviewService
    {
        private readonly IInterviewRepository _interviewRepository;

        //
        // Summary:
        //     /// Method responsible for initializing the service. ///
        //
        // Parameters:
        //   interviewRepository:
        //     The interviewRepository param.
        //
        public InterviewService(IInterviewRepository interviewRepository)
            => _interviewRepository = interviewRepository;

        public Task<Interview> AddAsync(InterviewCommand command)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Interview> UpdateAsync(InterviewCommand command, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}