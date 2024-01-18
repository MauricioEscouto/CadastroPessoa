using Api.Services.Abstractions;
using Api.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaServices _services;

        public PessoaController(IPessoaServices services)
        {
            _services = services;
        }

        [HttpPost]
        [Route("CadastrarPessoaFisica")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> CadastrarPessoaFisica([FromBody] PessoaFisica request)
        {
            return await _services.Cadastrar(request);
        }
    }
}
