using Api.Shared.Entities;
using Api.Shared.Entities.Abstractions;

namespace Api.Repositories.Abstractions
{
    public interface IPessoaRepository
    {
        Task<List<object>> ObterPessoas();
        Task<List<Endereco>> ObterEnderecos();
        Task<List<Contato>> ObterContatos();
        Task<int> CadastrarPessoaFisica(PessoaFisica pessoa);
        Task<Task> CadastrarEndereco(Endereco endereco, int idPessoa);
        Task<Task> CadastrarContato(Contato contato, int idPessoa);
    }
}