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
        [Route("Cadastrar")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> Cadastrar([FromBody] Usuario request)
        {
            return await _services.Cadastrar(request);
        }

        [HttpGet]
        [Route("Logar")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> Logar(string Email, string Senha)
        {
            return await _services.Logar(new Usuario { Email = Email, Senha = Senha });
        }
    }
}
