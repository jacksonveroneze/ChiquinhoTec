using ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Repositories;
using ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
    }
}