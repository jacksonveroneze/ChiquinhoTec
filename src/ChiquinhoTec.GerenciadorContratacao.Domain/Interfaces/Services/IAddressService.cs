using System;
using System.Threading.Tasks;
using ChiquinhoTec.GerenciadorContratacao.Common;
using ChiquinhoTec.GerenciadorContratacao.Domain.Entities;

namespace ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Services
{
    //
    // Summary:
    //     /// Interface responsible for contrat. ///
    //
    public interface IAddressService : IBaseService
    {
        Task<Address> AddAsync(AddressCommand command);

        Task RemoveAsync(Guid id);

        Task<Address> UpdateAsync(AddressCommand command, Guid id);
    }
}