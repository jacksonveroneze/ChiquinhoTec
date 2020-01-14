using System;

namespace ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Services
{
    //
    // Summary:
    //     /// Interface responsible for contrat. ///
    //
    public class IPersonService : IBaseService
    {
        Task<Person> AddAsync(PersonCommand command);

        Task RemoveAsync(Guid id);

        Task<Person> UpdateAsync(PersonCommand command, Guid id);
    }
}