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
    public class InterviewService : BaseService, IInterviewService
    {
        private readonly IInterviewRepository _interviewRepository;
        private readonly IPersonRepository _personRepository;
        //
        private readonly IEntityAuditService _entityAuditService;
        //
        private readonly IValidator<InterviewCommand> _interviewValidator;

        //
        // Summary:
        //     /// Method responsible for initializing the service. ///
        //
        // Parameters:
        //   interviewRepository:
        //     The interviewRepository param.
        //
        //   personRepository:
        //     The personRepository param.
        //
        //   entityAuditService:
        //     The entityAuditService param.
        //
        //   interviewValidator:
        //     The interviewValidator param.
        //
        public InterviewService(IInterviewRepository interviewRepository, IPersonRepository personRepository, IEntityAuditService entityAuditService, IValidator<InterviewCommand> interviewValidator)
        {
            _interviewRepository = interviewRepository;
            _personRepository = personRepository;
            _entityAuditService = entityAuditService;
            _interviewValidator = interviewValidator;
        }

        //
        // Summary:
        //     /// Method responsible for create registry. ///
        //
        // Parameters:
        //   command:
        //     The command param.
        //
        public async Task<Interview> AddAsync(InterviewCommand command)
        {
            _validationResult = await _interviewValidator.ValidateAsync(command);

            if (_validationResult.IsValid is false)
                return null;

            Person person = await _personRepository.FindAsync(command.PersonId);

            Interview interview = new Interview(command.SchedulingDate, command.Squad, person);

            await _interviewRepository.AddAsync(interview);

            await _entityAuditService.AddAsync("INS", nameof(Interview), interview);

            return interview;
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
            Interview interview = await _interviewRepository.FindAsync(id);

            if (interview is null)
            {
                _validationResult.Errors.Add(new ValidationFailure("Id", "Registro não encontrado."));

                return false;
            }

            await _interviewRepository.RemoveAsync(interview);

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
        public async Task<Interview> UpdateAsync(InterviewCommand command, Guid id)
        {
            _validationResult = await _interviewValidator.ValidateAsync(command);

            if (_validationResult.IsValid is false)
                return null;

            Interview interview = await _interviewRepository.FindAsync(id);

            interview.Update(command.SchedulingDate, command.Squad);

            await _interviewRepository.UpdateAsync(interview);

            await _entityAuditService.AddAsync("UPD", nameof(Interview), interview);

            return interview;
        }
    }
}