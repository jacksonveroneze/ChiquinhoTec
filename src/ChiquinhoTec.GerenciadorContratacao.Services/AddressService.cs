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
        private readonly IEntityAuditService _entityAuditService;
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
        //   entityAuditService:
        //     The entityAuditService param.
        //
        //   addressValidator:
        //     The addressValidator param.
        //
        public AddressService(IAddressRepository addressRepository, IPersonRepository personRepository, IEntityAuditService entityAuditService, IValidator<AddressCommand> addressValidator)
        {
            _addressRepository = addressRepository;
            _personRepository = personRepository;
            _entityAuditService = entityAuditService;
            _addressValidator = addressValidator;
        }

        //
        // Summary:
        //     /// Method responsible for create registry. ///
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

            if (command.PrimaryAddress is true)
            {
                Address currentPrimaryAddress = await _addressRepository.FindCurrentPrimaryAddressByPersonId(command.PersonId);

                if (currentPrimaryAddress != null)
                {
                    currentPrimaryAddress.UpdatePrimaryAddress(false);

                    await _addressRepository.UpdateAsync(currentPrimaryAddress);
                }
            }

            Person person = await _personRepository.FindAsync(command.PersonId);

            Address address = new Address(command.PostalCode, command.State, command.City, command.District, command.Street, command.StreetNumber, command.Complement, command.PrimaryAddress, person);

            await _addressRepository.AddAsync(address);

            await _entityAuditService.AddAsync("INS", nameof(Address), address);

            return address;
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
            Address address = await _addressRepository.FindAsync(id);

            if (address is null)
            {
                _validationResult.Errors.Add(new ValidationFailure("Id", "Registro não encontrado."));

                return false;
            }

            await _addressRepository.RemoveAsync(address);

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
        public async Task<Address> UpdateAsync(AddressCommand command, Guid id)
        {
            _validationResult = await _addressValidator.ValidateAsync(command);

            if (_validationResult.IsValid is false)
                return null;

            if (command.PrimaryAddress is true)
            {
                Address currentPrimaryAddress = await _addressRepository.FindCurrentPrimaryAddressByPersonId(command.PersonId);

                if (currentPrimaryAddress != null && currentPrimaryAddress.Id != id)
                {
                    currentPrimaryAddress.UpdatePrimaryAddress(false);

                    await _addressRepository.UpdateAsync(currentPrimaryAddress);
                }
            }

            Address address = await _addressRepository.FindAsync(id);

            address.Update(command.PostalCode, command.State, command.City, command.District, command.Street, command.StreetNumber, command.Complement, command.PrimaryAddress);

            await _addressRepository.UpdateAsync(address);

            await _entityAuditService.AddAsync("UPD", nameof(Address), address);

            return address;
        }
    }
}