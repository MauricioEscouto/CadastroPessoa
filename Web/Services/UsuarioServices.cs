using Microsoft.AspNetCore.Mvc;
using Web.Shared.Domain;
using Web.Shared.Entities;
using Web.WebService;

namespace Web.Services
{
    public class UsuarioServices
    {
        private readonly OutputPort _outputPort;
        private readonly UsuarioWebService _webService;

        public UsuarioServices(OutputPort outputPort, UsuarioWebService webService)
        {
            _outputPort = outputPort;
            _webService = webService;
        }

        public async Task<IActionResult> Logar(UsuarioEntity usuario)
        {
            if (string.IsNullOrEmpty(usuario.Email) || string.IsNullOrEmpty(usuario.Senha))
            {
                return _outputPort.BadRequest("É necessário preencher os campos de Email e senha para prosseguir.");
            }

            var response = await _webService.Logar(usuario) as ObjectResult;
            if (response!.StatusCode == 200)
            {
                UsuarioEntity usuarioObtido = CamadaTransporte.FromJson<UsuarioEntity>(response);
                Sessao.Set(usuarioObtido);
                return _outputPort.Success(usuarioObtido);
            }
            else
            {
                return _outputPort.StatusCode((int)response.StatusCode!, response.Value!);
            }
        }

        public async Task<IActionResult> Cadastrar(UsuarioEntity usuario)
        {
            if (string.IsNullOrEmpty(usuario.Nome) || string.IsNullOrEmpty(usuario.Email) || string.IsNullOrEmpty(usuario.Telefone) || string.IsNullOrEmpty(usuario.Senha))
            {
                return _outputPort.BadRequest("É necessário preencher todos os campos obrigatórios para prosseguir.");
            }

            var response = await _webService.Cadastrar(usuario) as ObjectResult;
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
