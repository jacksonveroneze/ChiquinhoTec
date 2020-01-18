using System;
using System.Threading.Tasks;
using ChiquinhoTec.GerenciadorContratacao.Domain.Commands;
using ChiquinhoTec.GerenciadorContratacao.Domain.Entities;
using ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Repositories;
using ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Services;
using ChiquinhoTec.GerenciadorContratacao.Domain.ValueObjects;

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

        //
        // Summary:
        //     /// Method responsible for create person. ///
        //
        // Parameters:
        //   command:
        //     The command param.
        //
        public async Task<Person> AddAsync(PersonCommand command)
        {
            Cpf cpf = new Cpf(command.Cpf);
            Email email = new Email(command.Email);

            if (await _personRepository.FindPersonByCpfAsync(command.Cpf) != null)
            {
                return null;
            }

            Person person = new Person(command.Name, command.BirthDate, cpf, command.Phone, email, command.Profile, command.ProfessionalDescription);

            await _personRepository.AddAsync(person);

            return person;
        }

        //
        // Summary:
        //     /// Method responsible for remove person. ///
        //
        // Parameters:
        //   id:
        //     The id param.
        //
        public async Task RemoveAsync(Guid id)
        {
            Person person = await _personRepository.FindAsync(id);

            if(person is null)
                throw new Exception("Registro não encontrado.");

            await _personRepository.RemoveAsync(person);
        }
    }
}