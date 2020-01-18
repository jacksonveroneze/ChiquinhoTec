﻿using ChiquinhoTec.GerenciadorContratacao.Domain.Commands;
using ChiquinhoTec.GerenciadorContratacao.Domain.Entities;
using ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Repositories;
using ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace ChiquinhoTec.GerenciadorContratacao.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InterviewsController : ControllerBase
    {
        private readonly ILogger<InterviewsController> _logger;
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
        //   interviewRepository:
        //     The interviewRepository param.
        //
        //   interviewService:
        //     The interviewService param.
        //
        public InterviewsController(ILogger<InterviewsController> logger, IInterviewRepository interviewRepository, IInterviewService interviewService)
        {
            _logger = logger;
            _interviewRepository = interviewRepository;
            _interviewService = interviewService;
        }

        //
        // Summary:
        //     /// Method responsible for action: index. ///
        //
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Index");

            return Ok(await _interviewRepository.FindAllAsync());
        }

        //
        // Summary:
        //     /// Method responsible for action: Create(POST). ///
        //
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] InterviewCommand command)
        {
            Interview interview = await _interviewService.AddAsync(command);

            if (interview is null)
                return BadRequest(_interviewService.ValidationResult());

            return Ok(interview);
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
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id is null)
                return NotFound();

            bool result = await _interviewService.RemoveAsync((Guid)id);

            if (result is false)
                return BadRequest(_interviewService.ValidationResult());

            return NoContent();
        }
    }
}