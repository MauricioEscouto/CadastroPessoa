using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Web.Services;
using Web.Shared.Domain;
using Web.Shared.Entities;

namespace Web.Controllers
{
    [Route("/[controller]")]
    public class PessoaController : Controller
    {
        private readonly PessoaServices _services;

        public PessoaController(PessoaServices services)
        {
            _services = services;
        }

        [HttpPost("CadastrarPessoaFisica")]
        public async Task<IActionResult> CadastrarPessoaFisica([FromBody] PessoaFisicaEntity pessoaFisica)
        {
            try
            {
                return await _services.CadastrarPessoaFisica(pessoaFisica);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Ocorreu um erro inesperado ao tentar cadastrar. Por favor, tente novamente.");
            }
        }
    }
}
