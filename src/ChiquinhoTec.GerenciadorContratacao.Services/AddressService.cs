using System;
using System.Threading.Tasks;
using ChiquinhoTec.GerenciadorContratacao.Common;
using ChiquinhoTec.GerenciadorContratacao.Domain.Commands;
using ChiquinhoTec.GerenciadorContratacao.Domain.Entities;
using ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Repositories;
using ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Services;
using FluentValidation;
using FluentValidation.Results;

namespace ChiquinhoTec.GerenciadorContratacao.Services
{
    //
    // Summary:
    //     /// Class responsible for the service. ///
    //
    public class AddressService : BaseService, IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IPersonRepository _personRepository;
        //
        private readonly IValidator<AddressCommand> _addressValidator;

        //
        // Summary:
        //     /// Method responsible for initializing the service. ///
        //
        // Parameters:
        //   addressRepository:
        //     The addressRepository param.
        //
        //   personRepository:
        //     The personRepository param.
        //
        //   addressValidator:
        //     The addressValidator param.
        //
        public AddressService(IAddressRepository addressRepository, IPersonRepository personRepository, IValidator<AddressCommand> addressValidator)
        {
            _addressRepository = addressRepository;
            _personRepository = personRepository;
            _addressValidator = addressValidator;
        }

        //
        // Summary:
        //     /// Method responsible for create address. ///
        //
        // Parameters:
        //   command:
        //     The command param.
        //
        public async Task<Address> AddAsync(AddressCommand command)
        {
            _validationResult = await _addressValidator.ValidateAsync(command);

            if (_validationResult.IsValid is false)
                return null;

            Person person = await _personRepository.FindAsync(command.PersonId);

            Address address = new Address(command.PostalCode, command.State, command.City, command.District, command.Street, command.StreetNumber, command.Complement, command.PrimaryAddress, person);

            await _addressRepository.AddAsync(address);

            return address;
        }

        //
        // Summary:
        //     /// Method responsible for remove address. ///
        //
        // Parameters:
        //   id:
        //     The id param.
        //
        public async Task<bool> RemoveAsync(Guid id)
        {
            Address address = await _addressRepository.FindAsync(id);

            if (address is null)
            {
                _validationResult.Errors.Add(new ValidationFailure("Id", "Registro não encontrado."));

                return false;
            }

            await _addressRepository.RemoveAsync(address);

            return true;
        }
    }
}