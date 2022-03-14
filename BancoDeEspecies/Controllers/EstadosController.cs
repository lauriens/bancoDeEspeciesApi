using BancoDeEspecies.Application.Services;
using BancoDeEspecies.Application.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace BancoDeEspecies.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosController : ControllerBase
    {
        private readonly ILogger<EstadosController> _logger;
        private readonly IEstadoService _estadoService;

        public EstadosController(ILogger<EstadosController> logger, IEstadoService estadoService)
        {
            _logger = logger;
            _estadoService = estadoService;
        }

        [HttpGet]
        public async Task<IActionResult> ListAllAsync()
        {
            _logger.LogInformation(Constants.InitiatingEndpointLog, "ListAllAsync", "Estados");

            var response = await _estadoService.ListAllAsync();

            _logger.LogInformation(Constants.FinalizingEndpointLog, "ListAllAsync", "Estados");

            return Ok(response);
        }
    }
}
