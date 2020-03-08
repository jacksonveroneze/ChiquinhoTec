using ChiquinhoTec.GerenciadorContratacao.Common;
using System;
using System.Threading.Tasks;
using ChiquinhoTec.GerenciadorContratacao.Register.Domain.Commands;
using ChiquinhoTec.GerenciadorContratacao.Register.Domain.Entities;

namespace ChiquinhoTec.GerenciadorContratacao.Register.Domain.Interfaces.Services
{
    //
    // Summary:
    //     /// Interface responsible for contrat. ///
    //
    public interface IAddressService : IBaseService
    {
        Task<Address> AddAsync(AddressCommand command);

        Task<bool> RemoveAsync(Guid id);

        Task<Address> UpdateAsync(AddressCommand command, Guid id);
    }
}