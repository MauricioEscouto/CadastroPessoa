using Api.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Services.Abstractions
{
    public interface IUsuarioServices
    {
        Task<IActionResult> Criar(Usuario usuario);
    }
}
