using AutoMapper;
using ChiquinhoTec.GerenciadorContratacao.Domain.Commands;
using ChiquinhoTec.GerenciadorContratacao.Domain.Entities;
using ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Repositories;
using ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Services;
using ChiquinhoTec.GerenciadorContratacao.Domain.Results;
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
    public class AddressesController : ControllerBase
    {
        private readonly ILogger<AddressesController> _logger;
        //
        private readonly IMapper _mapper;
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
        //   mapper:
        //     The mapper param.
        //
        //   addressesRepository:
        //     The addressesRepository param.
        //
        //   addressesService:
        //     The addressesService param.
        //
        public AddressesController(ILogger<AddressesController> logger, IMapper mapper, IAddressRepository addressesRepository, IAddressService addressesService)
        {
            _logger = logger;
            _mapper = mapper;
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
            List<Address> list = await _addressRepository.FindAllAsync();

            return Ok(_mapper.Map<List<Address>, List<AddressResult>>(list));
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
                return BadRequest(_addressService.ValidationResult()
                    .Errors
                    .Select(x => new ValidationResult() { PropertyName = x.PropertyName, ErrorMessage = x.ErrorMessage }));

            return Ok(_mapper.Map<Address, AddressResult>(address));
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
                return BadRequest(_addressService.ValidationResult()
                    .Errors
                    .Select(x => new ValidationResult() { PropertyName = x.PropertyName, ErrorMessage = x.ErrorMessage }));

            return Ok(_mapper.Map<Address, AddressResult>(address));
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