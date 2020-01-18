using ChiquinhoTec.GerenciadorContratacao.Domain.Commands;
using ChiquinhoTec.GerenciadorContratacao.Domain.Entities;
using ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Repositories;
using FluentValidation;

namespace ChiquinhoTec.GerenciadorContratacao.Services.Validators
{
    //
    // Summary:
    //     /// Class responsible for the validator. ///
    //
    public class InterviewValidator : AbstractValidator<InterviewCommand>
    {
        //
        // Summary:
        //     /// Method responsible for initializing the validator. ///
        //
        // Parameters:
        //   personRepository:
        //     The personRepository param.
        //
        public InterviewValidator(IPersonRepository personRepository)
        {
            RuleFor(x => x.SchedulingDate).NotEmpty();
            RuleFor(x => x.Squad).NotEmpty();

            RuleFor(x => x.PersonId)
                .NotEmpty()
                .MustAsync(async (x, c) =>
                {
                    Person person = await personRepository.FindAsync(x);

                    return person != null;
                }).WithMessage("PersonId não localizado.");
        }
    }
}