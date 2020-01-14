using System;

namespace ChiquinhoTec.GerenciadorContratacao.Services
{
    //
    // Summary:
    //     /// Class responsible for the service. ///
    //
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;

        //
        // Summary:
        //     /// Method responsible for initializing the service. ///
        //
        // Parameters:
        //   supervisorRepository:
        //     The supervisorRepository param.
        //
        public EnderecoService(IEnderecoRepository enderecoRepository)
            => _enderecoRepository = enderecoRepository;
    }
}