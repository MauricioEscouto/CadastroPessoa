using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using Web.Shared.Domain;
using Web.Shared.Entities;
using Web.WebService;

namespace Web.Services
{
    public class PessoaServices
    {
        private readonly OutputPort _outputPort;
        private readonly PessoaWebService _webService;

        public PessoaServices(OutputPort outputPort, PessoaWebService webService)
        {
            _outputPort = outputPort;
            _webService = webService;
        }

        public async Task<IActionResult> CadastrarPessoaFisica([FromBody] PessoaFisicaEntity pessoa)
        {
            var response = await _webService.CadastrarPessoaFisica(pessoa) as ObjectResult;
            if (response!.StatusCode == 200)
            {
                return _outputPort.Success(response);
            }
            else
            {
                return _outputPort.StatusCode((int)response.StatusCode!, response.Value!);
            }
        }
    }
}
