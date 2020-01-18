using ChiquinhoTec.GerenciadorContratacao.Domain.Commands;
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
    public class PersonsController : ControllerBase
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
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Index");

            return Ok(await _personRepository.FindAllAsync());
        }

        //
        // Summary:
        //     /// Method responsible for action: Create(POST). ///
        //
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PersonCommand command)
        {
            Person person = await _personService.AddAsync(command);

            if (person is null)
                return BadRequest(_personService.ValidationResult());

            return Ok(person);
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

            bool result = await _personService.RemoveAsync((Guid)id);

            if (result is false)
                return BadRequest(_personService.ValidationResult());

            return NoContent();
        }
    }
}