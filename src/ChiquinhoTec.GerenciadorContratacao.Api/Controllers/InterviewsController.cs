using AutoMapper;
using ChiquinhoTec.GerenciadorContratacao.Domain.Commands;
using ChiquinhoTec.GerenciadorContratacao.Domain.Entities;
using ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Repositories;
using ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Services;
using ChiquinhoTec.GerenciadorContratacao.Domain.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChiquinhoTec.GerenciadorContratacao.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InterviewsController : ControllerBase
    {
        private readonly ILogger<InterviewsController> _logger;
        //
        private readonly IMapper _mapper;
        //
        private readonly IInterviewRepository _interviewRepository;
        //
        private readonly IInterviewService _interviewService;

        //
        // Summary:
        //     /// Method responsible for initializing the controller. ///
        //
        // Parameters:
        //   logger:
        //     The logger param.
        //
        //   mapper:
        //     The mapper param.
        //
        //   interviewRepository:
        //     The interviewRepository param.
        //
        //   interviewService:
        //     The interviewService param.
        //
        public InterviewsController(ILogger<InterviewsController> logger, IMapper mapper, IInterviewRepository interviewRepository, IInterviewService interviewService)
        {
            _logger = logger;
            _mapper = mapper;
            _interviewRepository = interviewRepository;
            _interviewService = interviewService;
        }

        //
        // Summary:
        //     /// Method responsible for action: index. ///
        //
        [HttpGet]
        [Authorize("read:interview")]
        public async Task<IActionResult> Index([FromQuery] InterviewFilterCommand command)
        {
            List<Interview> list = await _interviewRepository.FindByFilterAsync(command);

            return Ok(_mapper.Map<List<Interview>, List<InterviewResult>>(list));
        }

        //
        // Summary:
        //     /// Method responsible for action: Create(POST). ///
        //
        [HttpPost]
        [Authorize("create:interview")]
        public async Task<IActionResult> Create([FromBody] InterviewCommand command)
        {
            if (command is null)
                return BadRequest();

            Interview interview = await _interviewService.AddAsync(command);

            if (interview is null)
                return BadRequest(_interviewService.ValidationResult()
                    .Errors
                    .Select(x => new ValidationResult() { PropertyName = x.PropertyName, ErrorMessage = x.ErrorMessage }));

            return Ok(_mapper.Map<Interview, InterviewResult>(interview));
        }

        //
        // Summary:
        //     /// Method responsible for action: Update(PUT). ///
        //
        [HttpPut("{id}")]
        [Authorize("update:interview")]
        public async Task<IActionResult> Update([FromBody] InterviewCommand command, Guid? id)
        {
            if (command is null || id is null)
                return BadRequest();

            Interview interview = await _interviewService.UpdateAsync(command, (Guid)id);

            if (interview is null)
                return BadRequest(_interviewService.ValidationResult()
                    .Errors
                    .Select(x => new ValidationResult() { PropertyName = x.PropertyName, ErrorMessage = x.ErrorMessage }));

            return Ok(_mapper.Map<Interview, InterviewResult>(interview));
        }

        //
        // Summary:
        //     /// Method responsible for action: Delete. ///
        //
        // Parameters:
        //   id:
        //     The id param.
        //
        [HttpDelete("{id}")]
        [Authorize("remove:interview")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id is null)
                return BadRequest();

            bool result = await _interviewService.RemoveAsync((Guid)id);

            if (result is false)
                return BadRequest(_interviewService.ValidationResult());

            return NoContent();
        }
    }
}