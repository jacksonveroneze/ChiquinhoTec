using System;

namespace ChiquinhoTec.GerenciadorContratacao.Infra.Data.PessoaRepository
{
    //
    // Summary:
    //     /// Class responsible for the repository. ///
    //
    public class PessoaRepository : BaseRepository<Pessoa>, IPessoaRepository
    {
        //
        // Summary:
        //     /// Method responsible for initializing the repository. ///
        //
        // Parameters:
        //   context:
        //     The context param.
        //
        public PessoaRepository(ApplicationDbContext context) : base(context) { }
    }
}