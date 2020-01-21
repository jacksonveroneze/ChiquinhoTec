using ChiquinhoTec.GerenciadorContratacao.Domain.Commands;
using ChiquinhoTec.GerenciadorContratacao.Domain.Entities;
using ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Repositories;
using FluentValidation;
using System;

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
        //   interviewRepository:
        //     The interviewRepository param.
        //
        public InterviewValidator(IPersonRepository personRepository, IInterviewRepository interviewRepository)
        {
            RuleFor(x => x.SchedulingDate)
                .NotEmpty()
                .Must((x) => !(x.DayOfWeek == DayOfWeek.Saturday || x.DayOfWeek == DayOfWeek.Sunday))
                .WithMessage("Não é permitido o agendamento de entrevistas para o final de semana.")
                .Must((x) => x.Hour >= 13 && x.Hour <= 20)
                .WithMessage("Não é permitido o agendamento fora do período (13:00 - 20:00).")
                .Must((x) => x.Minute == 0 || x.Minute == 30)
                .WithMessage("O horário de inicio e termino das entrevistas devem sempre terminar em 00 ou 30(ex: 14:30, 16:00).")
                .MustAsync(async (request, val, token) =>
                {
                    Interview interview = await interviewRepository.FindInterviewByPersonIdAndDate(request.PersonId, request.SchedulingDate);

                    return interview is null;
                })
                .WithMessage("Deve haver um intervalo de 3 horas entre as entrevistas para o mesmo candidato no mesmo dia.")
                .MustAsync(async (request, val, token) =>
                 {
                     Interview interview = await interviewRepository.FindInterviewBySquadAndDate(request.Squad, request.SchedulingDate);

                     return interview is null;
                 })
                .WithMessage("Deve haver um intervalo de 3 horas entre as entrevistas para o mesmo squad no mesmo dia.");

            RuleFor(x => x.Squad)
                .IsInEnum()
                .WithMessage("Squad inválido, forneça opções entre 1 - 8.");

            RuleFor(x => x.PersonId)
                .NotEmpty()
                .MustAsync(async (request, val, token) =>
                {
                    Person person = await personRepository.FindAsync(val);

                    return person != null;
                }).WithMessage("O valor informado em PersonId não localizado no banco de dados.")
                .MustAsync(async (request, val, token) =>
                {
                    Interview interview = await interviewRepository.FindInterviewCurrentYearByPersonIdAndSquad(request.PersonId, request.Squad);

                    if (interview is null)
                        return true;

                    if (request.Id is null)
                        return false;

                    if (request.Id != null && interview.Id == request.Id)
                        return true;

                    return false;
                })
                .WithMessage("Já existe uma entrevista agendada para este candidato e squad neste ano.");
        }
    }
}
