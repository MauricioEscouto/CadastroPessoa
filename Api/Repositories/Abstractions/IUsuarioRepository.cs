using Api.Shared.Entities;

namespace Api.Repositories.Abstractions
{
    public interface IUsuarioRepository
    {
        Task<Task> Cadastrar(Usuario usuario);
        Task<Usuario?> Logar(Usuario usuario);
    }
}
