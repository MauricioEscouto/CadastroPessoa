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

        public async Task<IActionResult> Criar(Usuario usuario)
        {
            await _repository.Criar(usuario);
            return _outputPort.Success(Task.CompletedTask);
        }
    }
}
