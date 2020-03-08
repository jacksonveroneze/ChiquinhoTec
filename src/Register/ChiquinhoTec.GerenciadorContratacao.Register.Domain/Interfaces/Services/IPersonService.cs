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
    public interface IPersonService : IBaseService
    {
        Task<Person> AddAsync(PersonCommand command);

        Task<bool> RemoveAsync(Guid id);

        Task<Person> UpdateAsync(PersonCommand command, Guid id);
    }
}