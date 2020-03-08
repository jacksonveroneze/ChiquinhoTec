using ChiquinhoTec.GerenciadorContratacao.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChiquinhoTec.GerenciadorContratacao.Register.Domain.Entities;

namespace ChiquinhoTec.GerenciadorContratacao.Register.Domain.Interfaces.Repositories
{
    //
    // Summary:
    //     /// Interface responsible for contrat. ///
    //
    public interface IAddressRepository : IBaseRepository<Address>
    {
        Task<List<Address>> FindAddressesByPersonId(Guid personId);

        Task<Address> FindCurrentPrimaryAddressByPersonId(Guid personId);

        bool HasAddressesByPersonId(Guid personId);
    }
}