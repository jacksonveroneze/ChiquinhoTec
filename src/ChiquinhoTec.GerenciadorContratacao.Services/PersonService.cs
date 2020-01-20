using ChiquinhoTec.GerenciadorContratacao.Common;
using ChiquinhoTec.GerenciadorContratacao.Domain.Commands;
using ChiquinhoTec.GerenciadorContratacao.Domain.Entities;
using ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Repositories;
using ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Services;
using ChiquinhoTec.GerenciadorContratacao.Domain.ValueObjects;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace ChiquinhoTec.GerenciadorContratacao.Services
{
    //
    // Summary:
    //     /// Class responsible for the service. ///
    //
    public class PersonService : BaseService, IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IInterviewRepository _interviewRepository;
        //
        private readonly IEntityAuditService _entityAuditService;
        //
        private readonly IValidator<PersonCommand> _personValidator;

        //
        // Summary:
        //     /// Method responsible for initializing the service. ///
        //
        // Parameters:
        //   personRepository:
        //     The personRepository param.
        //
        //   addressRepository:
        //     The addressRepository param.
        //
        //   interviewRepository:
        //     The interviewRepository param.
        //
        //   entityAuditService:
        //     The entityAuditService param.
        //
        //   personValidator:
        //     The personValidator param.
        //
        public PersonService(IPersonRepository personRepository, IAddressRepository addressRepository, IInterviewRepository interviewRepository, IEntityAuditService entityAuditService, IValidator<PersonCommand> personValidator)
        {
            _personRepository = personRepository;
            _addressRepository = addressRepository;
            _interviewRepository = interviewRepository;
            _entityAuditService = entityAuditService;
            _personValidator = personValidator;
        }

        //
        // Summary:
        //     /// Method responsible for create registry. ///
        //
        // Parameters:
        //   command:
        //     The command param.
        //
        public async Task<Person> AddAsync(PersonCommand command)
        {
            _validationResult = await _personValidator.ValidateAsync(command);

            if (_validationResult.IsValid is false)
                return null;

            Person person = new Person(command.Name, command.BirthDate, new Cpf(command.Cpf), command.Phone, new Email(command.Email), command.Profile, command.ProfessionalDescription);

            await _personRepository.AddAsync(person);

            await _entityAuditService.AddAsync("INS", nameof(Person), person);

            return person;
        }

        //
        // Summary:
        //     /// Method responsible for remove registry. ///
        //
        // Parameters:
        //   id:
        //     The id param.
        //
        public async Task<bool> RemoveAsync(Guid id)
        {
            Person person = await _personRepository.FindAsync(id);

            if (person is null)
            {
                _validationResult.Errors.Add(new ValidationFailure("Id", "Registro não encontrado."));
            }

            if (_addressRepository.HasAddressesByPersonId(id))
                _validationResult.Errors.Add(new ValidationFailure("Id", "Esta pessoa possue endereços ativos, portanto não pode ser removida."));

            if (_interviewRepository.HasInterviewsByPersonId(id))
                _validationResult.Errors.Add(new ValidationFailure("Id", "Esta pessoa possue entrevistas ativas, portanto não pode ser removida."));

            if (_validationResult.IsValid is false)
                return false;

            await _personRepository.RemoveAsync(person);

            return true;
        }

        //
        // Summary:
        //     /// Method responsible for update registry. ///
        //
        // Parameters:
        //   command:
        //     The command param.
        //
        //   id:
        //     The id param.
        //
        public async Task<Person> UpdateAsync(PersonCommand command, Guid id)
        {
            _validationResult = await _personValidator.ValidateAsync(command);

            if (_validationResult.IsValid is false)
                return null;

            Person person = await _personRepository.FindAsync(id);

            person.Update(command.Name, command.BirthDate, new Cpf(command.Cpf), command.Phone, new Email(command.Email), command.Profile, command.ProfessionalDescription);

            await _personRepository.UpdateAsync(person);

            await _entityAuditService.AddAsync("UPD", nameof(Person), person);

            return person;
        }
    }
}