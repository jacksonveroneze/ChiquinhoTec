using System;
using System.Threading.Tasks;
using ChiquinhoTec.GerenciadorContratacao.Common;
using ChiquinhoTec.GerenciadorContratacao.Domain.Commands;
using ChiquinhoTec.GerenciadorContratacao.Domain.Entities;
using ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Repositories;
using ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Services;

namespace ChiquinhoTec.GerenciadorContratacao.Services
{
    //
    // Summary:
    //     /// Class responsible for the service. ///
    //
    public class AddressService : BaseService, IAddressService
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

        public Task<Address> AddAsync(AddressCommand command)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Address> UpdateAsync(AddressCommand command, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}