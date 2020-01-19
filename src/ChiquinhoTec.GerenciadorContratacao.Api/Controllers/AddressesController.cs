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
    public class AddressesController : ControllerBase
    {
        private readonly ILogger<AddressesController> _logger;
        //
        private readonly IAddressRepository _addressRepository;
        //
        private readonly IAddressService _addressService;

        //
        // Summary:
        //     /// Method responsible for initializing the controller. ///
        //
        // Parameters:
        //   logger:
        //     The logger param.
        //
        //   addressesRepository:
        //     The addressesRepository param.
        //
        //   addressesService:
        //     The addressesService param.
        //
        public AddressesController(ILogger<AddressesController> logger, IAddressRepository addressesRepository, IAddressService addressesService)
        {
            _logger = logger;
            _addressRepository = addressesRepository;
            _addressService = addressesService;
        }

        //
        // Summary:
        //     /// Method responsible for action: index. ///
        //
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await _addressRepository.FindAllAsync());
        }

        //
        // Summary:
        //     /// Method responsible for action: Create(POST). ///
        //
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddressCommand command)
        {
            if (command is null)
                return BadRequest();

            Address address = await _addressService.AddAsync(command);

            if (address is null)
                return BadRequest(_addressService.ValidationResult());

            return Ok(address);
        }

        //
        // Summary:
        //     /// Method responsible for action: Update(PUT). ///
        //
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] AddressCommand command, Guid? id)
        {
            if (command is null || id is null)
                return BadRequest();

            Address address = await _addressService.UpdateAsync(command, (Guid)id);

            if (address is null)
                return BadRequest(_addressService.ValidationResult());

            return Ok(address);
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

            bool result = await _addressService.RemoveAsync((Guid)id);

            if (result is false)
                return BadRequest(_addressService.ValidationResult());

            return NoContent();
        }
    }
}