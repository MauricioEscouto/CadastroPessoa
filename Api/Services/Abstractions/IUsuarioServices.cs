using Api.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Services.Abstractions
{
    public interface IUsuarioServices
    {
        Task<IActionResult> Cadastrar(Usuario usuario);
        Task<IActionResult> Logar(Usuario usuario);
    }
}
