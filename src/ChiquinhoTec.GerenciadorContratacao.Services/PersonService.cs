using System;

namespace ChiquinhoTec.GerenciadorContratacao.Services
{
    //
    // Summary:
    //     /// Class responsible for the service. ///
    //
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _PersonRepository;

        //
        // Summary:
        //     /// Method responsible for initializing the service. ///
        //
        // Parameters:
        //   supervisorRepository:
        //     The supervisorRepository param.
        //
        public PersonService(IPersonRepository PersonRepository)
            => _PersonRepository = PersonRepository;
    }
}