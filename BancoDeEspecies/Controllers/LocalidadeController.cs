using BancoDeEspecies.Application.Services;
using BancoDeEspecies.Application.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace BancoDeEspecies.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalidadeController : Controller
    {
        private readonly ILogger<LocalidadeController> _logger;
        private readonly ILocalidadeService _localidadeService;

        public LocalidadeController(ILogger<LocalidadeController> logger, ILocalidadeService localidadeService)
        {
            _logger = logger;
            _localidadeService = localidadeService;
        }

        [HttpGet]
        public async Task<IActionResult> ListAllAsync()
        {
            _logger.LogInformation(Constants.InitiatingEndpointLog, "ListAllAsync", "Localidades");

            var response = await _localidadeService.ListAllAsync();

            _logger.LogInformation(Constants.FinalizingEndpointLog, "ListAllAsync", "Localidades");

            return Ok(response);
        }
    }
}
