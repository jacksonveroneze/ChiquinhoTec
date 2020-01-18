using ChiquinhoTec.GerenciadorContratacao.Domain.Commands;
using ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Repositories;
using ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace ChiquinhoTec.GerenciadorContratacao.Web.Controllers
{
    [Authorize]
    public class PersonsController : Controller
    {
        private readonly ILogger<PersonsController> _logger;
        //
        private readonly IPersonRepository _personRepository;
        //
        private readonly IPersonService _personService;

        //
        // Summary:
        //     /// Method responsible for initializing the controller. ///
        //
        // Parameters:
        //   logger:
        //     The logger param.
        //
        //   personRepository:
        //     The personRepository param.
        //
        //   personService:
        //     The personService param.
        //
        public PersonsController(ILogger<PersonsController> logger, IPersonRepository personRepository, IPersonService personService)
        {
            _logger = logger;
            _personRepository = personRepository;
            _personService = personService;
        }

        //
        // Summary:
        //     /// Method responsible for action: index. ///
        //
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Index");

            return View(await _personRepository.FindAllAsync());
        }

        //
        // Summary:
        //     /// Method responsible for action: Create(GET). ///
        //
        public IActionResult Create()
        {
            _logger.LogInformation("Create");

            return View();
        }

        //
        // Summary:
        //     /// Method responsible for action: Create(POST). ///
        //
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] PersonCommand command)
        {
            if (ModelState.IsValid)
            {
                await _personService.AddAsync(command);

                return RedirectToAction(nameof(Index));
            }

            return View(command);
        }

        //
        // Summary:
        //     /// Method responsible for action: Delete. ///
        //
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id is null)
                return NotFound();

            await _personService.RemoveAsync((Guid)id);

            return RedirectToAction(nameof(Index));
        }
    }
}