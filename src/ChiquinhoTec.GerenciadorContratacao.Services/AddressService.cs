using System;

namespace ChiquinhoTec.GerenciadorContratacao.Services
{
    //
    // Summary:
    //     /// Class responsible for the service. ///
    //
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        //
        // Summary:
        //     /// Method responsible for initializing the service. ///
        //
        // Parameters:
        //   addressRepository:
        //     The addressRepository param.
        //
        public AddressService(IAddressRepository addressRepository)
            => _addressRepository = addressRepository;
    }
}