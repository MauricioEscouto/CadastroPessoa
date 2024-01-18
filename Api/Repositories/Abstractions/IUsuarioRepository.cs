using Api.Shared.Entities;

namespace Api.Repositories.Abstractions
{
    public interface IUsuarioRepository
    {
        Task<Task> Criar(Usuario usuario);
    }
}
