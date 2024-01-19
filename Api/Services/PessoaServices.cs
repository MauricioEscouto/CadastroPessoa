using Api.Repositories.Abstractions;
using Api.Services.Abstractions;
using Api.Shared.Domain.Abstractions;
using Api.Shared.Entities;
using Api.Shared.Enum;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

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

        public async Task<IActionResult> ObterTodos()
        {
            List<dynamic> pessoas = new List<dynamic>();

            var resultadoPessoas = await _repository.ObterPessoas();
            var resultadoEnderecos = await _repository.ObterEnderecos();
            var resultadoContatos = await _repository.ObterContatos();

            if (resultadoPessoas != null && resultadoPessoas.Any())
            {
                for (var i = 0; i < resultadoPessoas.Count; i++)
                {
                    var pessoa = resultadoPessoas[i] as IDictionary<string, object>;
                    if (pessoa != null)
                    {
                        var json = JsonConvert.SerializeObject(pessoa);
                        EnumTipoDocumento tipoDocumento = (EnumTipoDocumento)((int)pessoa["TipoDocumento"]);
                        switch (tipoDocumento)
                        {
                            case EnumTipoDocumento.CPF:
                                PessoaFisica pessoaFisica = JsonSerializer.Deserialize<PessoaFisica>(json)!;
                                if (resultadoEnderecos != null)
                                {
                                    pessoaFisica.Enderecos.AddRange(resultadoEnderecos.Where(x => x.IdPessoa == pessoaFisica.Id));
                                }
                                if (resultadoContatos != null)
                                {
                                    pessoaFisica.Contatos.AddRange(resultadoContatos.Where(x => x.IdPessoa == pessoaFisica.Id));
                                }
                                pessoas.Add(pessoaFisica);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            return _outputPort.Success(pessoas);
        }

        public async Task<IActionResult> CadastrarPessoaFisica(PessoaFisica pessoa)
        {
            int idRegistrado = await _repository.CadastrarPessoaFisica(pessoa);
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