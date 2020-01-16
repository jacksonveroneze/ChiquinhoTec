using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ChiquinhoTec.GerenciadorContratacao.Web.Controllers
{
    public class InterviewsController : Controller
    {
        private readonly ILogger<InterviewsController> _logger;

        public InterviewsController(ILogger<InterviewsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}