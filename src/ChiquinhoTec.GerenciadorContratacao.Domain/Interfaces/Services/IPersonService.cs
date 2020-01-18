using System;
using System.Threading.Tasks;
using ChiquinhoTec.GerenciadorContratacao.Common;
using ChiquinhoTec.GerenciadorContratacao.Domain.Commands;
using ChiquinhoTec.GerenciadorContratacao.Domain.Entities;

namespace ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Services
{
    //
    // Summary:
    //     /// Interface responsible for contrat. ///
    //
    public interface IPersonService : IBaseService
    {
        Task<Person> AddAsync(PersonCommand command);

        Task RemoveAsync(Guid id);

        //Task<Person> UpdateAsync(PersonCommand command, Guid id);
    }
}