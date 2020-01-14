using System;

namespace ChiquinhoTec.GerenciadorContratacao.Infra.Data.EnderecoRepository
{
    //
    // Summary:
    //     /// Class responsible for the repository. ///
    //
    public class EnderecoRepository : BaseRepository<Endereco>, IEnderecoRepository
    {
        //
        // Summary:
        //     /// Method responsible for initializing the repository. ///
        //
        // Parameters:
        //   context:
        //     The context param.
        //
        public EnderecoRepository(ApplicationDbContext context) : base(context) { }
    }
}