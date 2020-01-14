using System;

namespace ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Services
{
    //
    // Summary:
    //     /// Interface responsible for contrat. ///
    //
    public class IAddressService : IBaseService
    {
        Task<Address> AddAsync(AddressCommand command);

        Task RemoveAsync(Guid id);

        Task<Address> UpdateAsync(AddressCommand command, Guid id);
    }
}