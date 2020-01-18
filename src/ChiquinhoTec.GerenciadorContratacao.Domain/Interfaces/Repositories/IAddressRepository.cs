using ChiquinhoTec.GerenciadorContratacao.Common;
using ChiquinhoTec.GerenciadorContratacao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Repositories
{
    //
    // Summary:
    //     /// Interface responsible for contrat. ///
    //
    public interface IAddressRepository : IBaseRepository<Address>
    {
        Task<List<Address>> FindAddressesByPersonId(Guid personId);
     
        bool HasAddressesByPersonId(Guid personId);
    }
}