using Api.Repositories.Abstractions;
using Api.Services.Abstractions;
using Api.Shared.Domain;
using Api.Shared.Domain.Abstractions;
using Api.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly IOutputPort _outputPort;
        private readonly IUsuarioRepository _repository;

        public UsuarioServices(IOutputPort outputPort, IUsuarioRepository repository)
        {
            _outputPort = outputPort;
            _repository = repository;
        }

        public async Task<IActionResult> Cadastrar(Usuario usuario)
        {
            if (!string.IsNullOrEmpty(usuario.Senha))
            {
                usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
            }
            await _repository.Cadastrar(usuario);
            return _outputPort.Success(Task.CompletedTask);
        }

        public async Task<IActionResult> Logar(Usuario usuario)
        {
            Usuario? usuarioObtido = await _repository.Logar(usuario);
            if (usuarioObtido != null)
            {
                bool senhasCoincidem = BCrypt.Net.BCrypt.Verify(usuario.Senha, usuarioObtido.Senha);
                if (!senhasCoincidem)
                {
                    return _outputPort.NotFound("A senha que você inseriu está incorreta. Por favor, verifique e tente novamente.");
                }
            }
            else
            {
                return _outputPort.NotFound("Usuário não encontrado. Por favor, verifique e tente novamente.");
            }

            return _outputPort.Success(usuarioObtido);
        }
    }
}
