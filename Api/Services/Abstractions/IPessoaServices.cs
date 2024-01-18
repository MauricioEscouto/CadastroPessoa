using Api.Shared.Entities.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Api.Services.Abstractions
{
    public interface IPessoaServices
    {
        Task<IActionResult> Cadastrar(IPessoa pessoa);
    }
}
