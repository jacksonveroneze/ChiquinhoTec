using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChiquinhoTec.GerenciadorContratacao.Domain.Commands;
using ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Repositories;
using ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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

        public PersonsController(ILogger<PersonsController> logger, IPersonRepository personRepository, IPersonService personService)
        {
            _logger = logger;
            _personRepository = personRepository;
            _personService = personService;
        }

        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Index");

            return View(await _personRepository.FindAllAsync());
        }
        
        public IActionResult Create()
        {
            _logger.LogInformation("Create");

            return View();
        }

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

        // GET: People/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id is null)
                return NotFound();

            await _personService.RemoveAsync((Guid)id);

            return RedirectToAction(nameof(Index));
        }
    }
}