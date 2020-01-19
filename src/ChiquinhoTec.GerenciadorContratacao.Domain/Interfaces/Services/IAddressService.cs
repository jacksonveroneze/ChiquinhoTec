using ChiquinhoTec.GerenciadorContratacao.Common;
using ChiquinhoTec.GerenciadorContratacao.Domain.Commands;
using ChiquinhoTec.GerenciadorContratacao.Domain.Entities;
using ChiquinhoTec.GerenciadorContratacao.Domain.Results;
using System;
using System.Threading.Tasks;

namespace ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Services
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