using ChiquinhoTec.GerenciadorContratacao.Domain.Commands;
using FluentValidation;

namespace ChiquinhoTec.GerenciadorContratacao.Services.Validators
{
    //
    // Summary:
    //     /// Class responsible for the validator. ///
    //
    public class PersonValidator : AbstractValidator<PersonCommand>
    {
        //
        // Summary:
        //     /// Method responsible for initializing the validator. ///
        //
        public PersonValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Length(2, 2);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
        }
    }
}