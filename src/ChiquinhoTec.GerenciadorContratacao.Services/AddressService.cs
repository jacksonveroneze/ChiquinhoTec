using System;

namespace ChiquinhoTec.GerenciadorContratacao.Services
{
    //
    // Summary:
    //     /// Class responsible for the service. ///
    //
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _AddressRepository;

        //
        // Summary:
        //     /// Method responsible for initializing the service. ///
        //
        // Parameters:
        //   supervisorRepository:
        //     The supervisorRepository param.
        //
        public AddressService(IAddressRepository AddressRepository)
            => _AddressRepository = AddressRepository;
    }
}