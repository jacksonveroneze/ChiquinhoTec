using ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Repositories;
using ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
    }
}