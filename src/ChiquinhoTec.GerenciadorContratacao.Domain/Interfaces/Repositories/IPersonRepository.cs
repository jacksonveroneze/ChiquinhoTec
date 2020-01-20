using System.Collections.Generic;
using System.Threading.Tasks;
using ChiquinhoTec.GerenciadorContratacao.Common;
using ChiquinhoTec.GerenciadorContratacao.Domain.Commands;
using ChiquinhoTec.GerenciadorContratacao.Domain.Entities;

namespace ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Repositories
{
    //
    // Summary:
    //     /// Interface responsible for contrat. ///
    //
    public interface IPersonRepository : IBaseRepository<Person> 
    {
        Task<List<Person>> FindByFilterAsync(PersonFilterCommand command);
     
        Task<Person> FindPersonByCpfAsync(string value);

        Task<Person> FindPersonByEmailAsync(string value);
    }
}