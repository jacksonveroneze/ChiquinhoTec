using System;

namespace ChiquinhoTec.GerenciadorContratacao.Services
{
    //
    // Summary:
    //     /// Class responsible for the service. ///
    //
    public class InterviewService : IInterviewService
    {
        private readonly IInterviewRepository _InterviewRepository;

        //
        // Summary:
        //     /// Method responsible for initializing the service. ///
        //
        // Parameters:
        //   supervisorRepository:
        //     The supervisorRepository param.
        //
        public InterviewService(IInterviewRepository InterviewRepository)
            => _InterviewRepository = InterviewRepository;
    }
}