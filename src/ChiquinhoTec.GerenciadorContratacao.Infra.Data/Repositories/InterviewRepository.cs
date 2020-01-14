using System;

namespace ChiquinhoTec.GerenciadorContratacao.Infra.Data.InterviewRepository
{
    //
    // Summary:
    //     /// Class responsible for the repository. ///
    //
    public class InterviewRepository : BaseRepository<Interview>, IInterviewRepository
    {
        //
        // Summary:
        //     /// Method responsible for initializing the repository. ///
        //
        // Parameters:
        //   context:
        //     The context param.
        //
        public InterviewRepository(ApplicationDbContext context) : base(context) { }
    }
}