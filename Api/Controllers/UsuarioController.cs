using Api.Services.Abstractions;
using Api.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServices _services;

        public UsuarioController(IUsuarioServices services) { 
            _services = services;
        }

        [HttpPost]
        [Route("Criar")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> Criar([FromBody] Usuario request)
        {
            return await _services.Criar(request);
        }
    }
}
