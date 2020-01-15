using System;
using System.Threading.Tasks;
using ChiquinhoTec.GerenciadorContratacao.Domain.Entities;
using ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Repositories;
using ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Services;

namespace ChiquinhoTec.GerenciadorContratacao.Services
{
    //
    // Summary:
    //     /// Class responsible for the service. ///
    //
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        //
        // Summary:
        //     /// Method responsible for initializing the service. ///
        //
        // Parameters:
        //   personRepository:
        //     The personRepository param.
        //
        public PersonService(IPersonRepository personRepository)
            => _personRepository = personRepository;

        public Task<Person> AddAsync(PersonCommand command)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Person> UpdateAsync(PersonCommand command, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}