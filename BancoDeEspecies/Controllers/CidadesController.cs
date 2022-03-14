using BancoDeEspecies.Application.Services;
using BancoDeEspecies.Application.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace BancoDeEspecies.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CidadesController : Controller
    {
        private readonly ILogger<CidadesController> _logger;
        private readonly ICidadeService _cidadeService;

        public CidadesController(ILogger<CidadesController> logger, ICidadeService cidadeService)
        {
            _logger = logger;
            _cidadeService = cidadeService;
        }

        [HttpGet]
        public async Task<IActionResult> ListAllAsync()
        {
            _logger.LogInformation(Constants.InitiatingEndpointLog, "ListAllAsync", "Cidades");

            var response = await _cidadeService.ListAllAsync();

            _logger.LogInformation(Constants.FinalizingEndpointLog, "ListAllAsync", "Cidades");

            return Ok(response);
        }
    }
}
