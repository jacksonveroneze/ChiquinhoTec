using System;

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
    }
}