using Api.Repositories.Abstractions;
using Api.Services.Abstractions;
using Api.Shared.Domain.Abstractions;
using Api.Shared.Entities.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Api.Services
{
    public class PessoaServices : IPessoaServices
    {
        private readonly IOutputPort _outputPort;
        private readonly IPessoaRepository _repository;

        public PessoaServices(IOutputPort outputPort, IPessoaRepository repository)
        {
            _outputPort = outputPort;
            _repository = repository;
        }

        public async Task<IActionResult> Cadastrar(IPessoa pessoa)
        {
            int idRegistrado = await _repository.CadastrarPessoa(pessoa);
            if (idRegistrado > -1)
            {
                foreach (var endereco in pessoa.Enderecos)
                {
                    await _repository.CadastrarEndereco(endereco, idRegistrado);
                }

                foreach (var contato in pessoa.Contatos)
                {
                    await _repository.CadastrarContato(contato, idRegistrado);
                }

                return _outputPort.Success(Task.CompletedTask);
            }
            else
            {
                return _outputPort.InvalidRequest("Ocorreu um erro para cadastrar a pessoa. Por favor, verifique e tente novamente.");
            }
        }
    }
}