using Api.Shared.Entities;
using Api.Shared.Entities.Abstractions;

namespace Api.Repositories.Abstractions
{
    public interface IPessoaRepository
    {
        Task<int> CadastrarPessoa(IPessoa pessoa);
        Task<Task> CadastrarEndereco(Endereco endereco, int idPessoa);
        Task<Task> CadastrarContato(Contato contato, int idPessoa);
    }
}