using ChiquinhoTec.GerenciadorContratacao.Domain.Commands;
using ChiquinhoTec.GerenciadorContratacao.Domain.Entities;
using ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Repositories;
using ChiquinhoTec.GerenciadorContratacao.Domain.Results;
using ChiquinhoTec.GerenciadorContratacao.Services.Interfaces.Refit;
using FluentValidation;
using Refit;
using System;

namespace ChiquinhoTec.GerenciadorContratacao.Services.Validators
{
    //
    // Summary:
    //     /// Class responsible for the validator. ///
    //
    public class AddressValidator : AbstractValidator<AddressCommand>
    {
        //
        // Summary:
        //     /// Method responsible for initializing the validator. ///
        //
        // Parameters:
        //   personRepository:
        //     The personRepository param.
        //
        public AddressValidator(IPersonRepository personRepository)
        {
            RuleFor(x => x.State).NotEmpty().Length(2, 2);
            RuleFor(x => x.City).NotEmpty().MaximumLength(100);
            RuleFor(x => x.District).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Street).NotEmpty().MaximumLength(100);
            RuleFor(x => x.StreetNumber).NotEmpty();

            RuleFor(x => x.PersonId)
            .NotEmpty()
            .MustAsync(async (request, val, token) =>
            {
                Person person = await personRepository.FindAsync(val);

                return person != null;
            }).WithMessage("PersonId não localizado.");

            RuleFor(x => x.PostalCode)
            .NotEmpty()
            .MustAsync(async (request, val, token) =>
            {
                ICepSearch cepSearch = RestService.For<ICepSearch>("https://viacep.com.br");

                CepResult cepResult = await cepSearch.Find(val);

                if (!(request.State.Equals(cepResult.Uf, StringComparison.OrdinalIgnoreCase) && request.City.Equals(cepResult.Localidade, StringComparison.OrdinalIgnoreCase)))
                    return false;

                if (!(!string.IsNullOrEmpty(cepResult.Logradouro) && !string.IsNullOrEmpty(cepResult.Bairro) &&
                    request.Street.Equals(cepResult.Logradouro, StringComparison.OrdinalIgnoreCase) &&
                    request.District.Equals(cepResult.Bairro, StringComparison.OrdinalIgnoreCase)))
                    return false;

                return true;

            }).WithMessage("Os dados informados não coincidem com os dados retornados do web-service.");
        }
    }
}