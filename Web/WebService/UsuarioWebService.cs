using Microsoft.AspNetCore.Mvc;
using Web.Shared.Domain;
using Web.Shared.Entities;

namespace Web.WebService
{
    public class UsuarioWebService
    {
        private readonly string apiUrl;

        public UsuarioWebService()
        {
            apiUrl = ApiConexao.GetApiUrl();
        }

        public async Task<IActionResult> Logar(UsuarioEntity usuario)
        {
            try
            {
                string caminho = $"{apiUrl}/Usuario/Logar?email={usuario.Email}&senha={usuario.Senha}";
                var response = await HttpRequestApi.GetData(caminho);
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IActionResult> Cadastrar(UsuarioEntity usuario)
        {
            try
            {
                string caminho = $"{apiUrl}/Usuario/Cadastrar";
                var response = await HttpRequestApi.PostData(caminho, usuario);
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
