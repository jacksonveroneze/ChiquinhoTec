using ChiquinhoTec.GerenciadorContratacao.Domain.Commands;
using FluentValidation;

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
        public AddressValidator()
        {
            RuleFor(x => x.PostalCode).NotEmpty();
            RuleFor(x => x.State).NotEmpty().Length(2, 2);
            RuleFor(x => x.City).NotEmpty().MaximumLength(100);
            RuleFor(x => x.District).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Street).NotEmpty().MaximumLength(100);
            RuleFor(x => x.StreetNumber).NotEmpty();
            RuleFor(x => x.PersonId).NotEmpty();
        }
    }
}