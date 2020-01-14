using System;

namespace ChiquinhoTec.GerenciadorContratacao.Infra.Data.EntrevistaRepository
{
    //
    // Summary:
    //     /// Class responsible for the repository. ///
    //
    public class EntrevistaRepository : BaseRepository<Entrevista>, IEntrevistaRepository
    {
        //
        // Summary:
        //     /// Method responsible for initializing the repository. ///
        //
        // Parameters:
        //   context:
        //     The context param.
        //
        public EntrevistaRepository(ApplicationDbContext context) : base(context) { }
    }
}