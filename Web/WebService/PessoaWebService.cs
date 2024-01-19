using Microsoft.AspNetCore.Mvc;
using Web.Shared.Domain;
using Web.Shared.Entities;

namespace Web.WebService
{
    public class PessoaWebService
    {
        private readonly string apiUrl;

        public PessoaWebService()
        {
            apiUrl = ApiConexao.GetApiUrl();
        }

        public async Task<IActionResult> CadastrarPessoaFisica(PessoaFisicaEntity pessoa)
        {
            try
            {
                string caminho = $"{apiUrl}/Pessoa/CadastrarPessoaFisica";
                var response = await HttpRequestApi.PostData(caminho, pessoa);
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
