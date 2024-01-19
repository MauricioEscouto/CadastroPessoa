using Microsoft.AspNetCore.Mvc;
using Web.Services;
using Web.Shared.Entities;

namespace Web.Controllers
{
    [Route("/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly UsuarioServices _services;

        public UsuarioController(UsuarioServices services)
        {
            _services = services;
        }

        [HttpPost("Logar")]
        public async Task<IActionResult> Logar([FromBody] UsuarioEntity usuario)
        {
            try
            {
                return await _services.Logar(usuario);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Ocorreu um erro inesperado ao tentar acessar sua conta. Por favor, tente novamente.");
            }
        }

        [HttpPost("Cadastrar")]
        public async Task<IActionResult> Cadastrar([FromBody] UsuarioEntity usuario)
        {
            try
            {
                return await _services.Cadastrar(usuario);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Ocorreu um erro inesperado ao tentar cadastrar sua conta. Por favor, tente novamente.");
            }
        }
    }
}
