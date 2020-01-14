using System;

namespace ChiquinhoTec.GerenciadorContratacao.Services
{
    //
    // Summary:
    //     /// Class responsible for the service. ///
    //
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _PessoaRepository;

        //
        // Summary:
        //     /// Method responsible for initializing the service. ///
        //
        // Parameters:
        //   supervisorRepository:
        //     The supervisorRepository param.
        //
        public PessoaService(IPessoaRepository PessoaRepository)
            => _PessoaRepository = PessoaRepository;
    }
}