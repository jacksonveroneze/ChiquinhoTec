using System;

namespace ChiquinhoTec.GerenciadorContratacao.Services
{
    //
    // Summary:
    //     /// Class responsible for the service. ///
    //
    public class EntrevistaService : IEntrevistaService
    {
        private readonly IEntrevistaRepository _EntrevistaRepository;

        //
        // Summary:
        //     /// Method responsible for initializing the service. ///
        //
        // Parameters:
        //   supervisorRepository:
        //     The supervisorRepository param.
        //
        public EntrevistaService(IEntrevistaRepository EntrevistaRepository)
            => _EntrevistaRepository = EntrevistaRepository;
    }
}