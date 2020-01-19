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
        private readonly IAddressRepository _addressRepository;
        private readonly IInterviewRepository _interviewRepository;
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
        //   addressRepository:
        //     The addressRepository param.
        //
        //   interviewRepository:
        //     The interviewRepository param.
        //
        //   personService:
        //     The personService param.
        //
        public PersonsController(ILogger<PersonsController> logger, IPersonRepository personRepository, IAddressRepository addressRepository, IInterviewRepository interviewRepository, IPersonService personService)
        {
            _logger = logger;
            _personRepository = personRepository;
            _addressRepository = addressRepository;
            _interviewRepository = interviewRepository;
            _personService = personService;
        }

        //
        // Summary:
        //     /// Method responsible for action: index. ///
        //
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] PersonFilterCommand command)
        {
            return Ok(await _personRepository.FindByFilterAsync(command));
        }

        //
        // Summary:
        //     /// Method responsible for action: index. ///
        //
        [HttpGet("{id}/Addresses")]
        public async Task<IActionResult> Addresses(Guid? id)
        {
            if (id is null)
                return BadRequest();

            return Ok(await _addressRepository.FindAddressesByPersonId((Guid)id));
        }

        //
        // Summary:
        //     /// Method responsible for action: index. ///
        //
        [HttpGet("{id}/Interviews")]
        public async Task<IActionResult> Interviews(Guid? id)
        {
            if (id is null)
                return BadRequest();

            return Ok(await _interviewRepository.FindInterviewsByPersonId((Guid)id));
        }

        //
        // Summary:
        //     /// Method responsible for action: Create(POST). ///
        //
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PersonCommand command)
        {
            if (command is null)
                return BadRequest();

            Person person = await _personService.AddAsync(command);

            if (person is null)
                return BadRequest(_personService.ValidationResult());

            return Ok(person);
        }

        //
        // Summary:
        //     /// Method responsible for action: Update(PUT). ///
        //
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] PersonCommand command, Guid? id)
        {
            if (command is null || id is null)
                return BadRequest();

            Person person = await _personService.UpdateAsync(command, (Guid)id);

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
                return BadRequest();

            bool result = await _personService.RemoveAsync((Guid)id);

            if (result is false)
                return BadRequest(_personService.ValidationResult());

            return NoContent();
        }
    }
}