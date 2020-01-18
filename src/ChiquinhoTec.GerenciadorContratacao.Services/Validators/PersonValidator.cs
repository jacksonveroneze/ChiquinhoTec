using ChiquinhoTec.GerenciadorContratacao.Domain.Commands;
using ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Repositories;
using FluentValidation;

namespace ChiquinhoTec.GerenciadorContratacao.Services.Validators
{
    //
    // Summary:
    //     /// Class responsible for the validator. ///
    //
    public class PersonValidator : AbstractValidator<PersonCommand>
    {
        private readonly IPersonRepository _personRepository;

        //
        // Summary:
        //     /// Method responsible for initializing the validator. ///
        //
        // Parameters:
        //   personRepository:
        //     The personRepository param.
        //
        public PersonValidator(IPersonRepository personRepository)
        {
            _personRepository = personRepository;

            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Cpf).NotEmpty().Must((x) =>
            {
                return _personRepository.FindPersonByCpfAsync(x).Result != null;
            }).WithMessage("CPF já encontra-se cadastrado.");
        }
    }
}