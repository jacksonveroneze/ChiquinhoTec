using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChiquinhoTec.GerenciadorContratacao.Domain.Commands;
using ChiquinhoTec.GerenciadorContratacao.Domain.Entities;
using ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Repositories;
using ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Services;
using ChiquinhoTec.GerenciadorContratacao.Domain.ValueObjects;
using ChiquinhoTec.GerenciadorContratacao.Services.Validators;
using FluentValidation;

namespace ChiquinhoTec.GerenciadorContratacao.Services
{
    //
    // Summary:
    //     /// Class responsible for the service. ///
    //
    public class PersonService : IPersonService
    {
        public IList<string> listErrors = new List<string>();

        private readonly IPersonRepository _personRepository;
        private readonly IValidator<PersonCommand> _personValidator;

        //
        // Summary:
        //     /// Method responsible for initializing the service. ///
        //
        // Parameters:
        //   personRepository:
        //     The personRepository param.
        //
        public PersonService(IPersonRepository personRepository, IValidator<PersonCommand> personValidator)
        {
            _personRepository = personRepository;
            _personValidator = personValidator;
        }

        public async Task<Person> AddAsync(PersonCommand command)
        {
            var result = _personValidator.Validate(command);

            // if (await _personRepository.FindPersonByCpfAsync(command.Cpf) != null)
            //     listErrors.Add("CPF já cadastrado.");

            // if (await _personRepository.FindPersonByEmailAsync(command.Email) != null)
            //     listErrors.Add("E-mail já cadastrado.");

            // if(listErrors.Count > 0)
            //     return null;

            Person person = new Person(command.Name, command.BirthDate, new Cpf(command.Cpf), command.Phone, new Email(command.Email), command.Profile, command.ProfessionalDescription);

            await _personRepository.AddAsync(person);

            return person;
        }

        public async Task RemoveAsync(Guid id)
        {
            Person person = await _personRepository.FindAsync(id);

            if (person is null)
                throw new Exception("Registro não encontrado.");

            await _personRepository.RemoveAsync(person);
        }

        public Task<Person> UpdateAsync(PersonCommand command, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}