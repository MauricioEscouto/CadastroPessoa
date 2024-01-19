using Microsoft.AspNetCore.Mvc;
using Web.Shared.Domain;

namespace Web.WebService
{
    public class UsuarioWebService
    {
        private readonly string apiUrl;

        public UsuarioWebService()
        {
            apiUrl = ApiConexao.GetApiUrl();
        }

        public async Task<IActionResult> Logar(object obj)
        {
            try
            {
                string caminho = $"{apiUrl}/Usuario/Logar";
                var response = await HttpRequestApi.GetData(caminho, obj);
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
