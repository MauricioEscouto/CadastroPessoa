using Api.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Services.Abstractions
{
    public interface IPessoaServices
    {
        Task<IActionResult> ObterTodos();
        Task<IActionResult> CadastrarPessoaFisica(PessoaFisica pessoa);
    }
}
