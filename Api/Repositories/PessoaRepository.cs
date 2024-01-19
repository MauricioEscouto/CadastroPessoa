using Api.Repositories.Abstractions;
using Api.Shared.Context;
using Api.Shared.Context.DbQuery;
using Api.Shared.Entities;
using Dapper;
using MySql.Data.MySqlClient;

namespace Api.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        public PessoaRepository()
        {
        }

        public async Task<List<object>> ObterPessoas()
        {
            using (var connection = new MySqlConnection(ConexaoSettings.ObterValorConexao()))
            {
                try
                {
                    await connection.OpenAsync();
                    var pessoas = (await connection.QueryAsync<object>(QuerysPessoa.ObterPessoa())).ToList();
                    connection.Close();

                    return pessoas;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public async Task<List<Endereco>> ObterEnderecos()
        {
            using (var connection = new MySqlConnection(ConexaoSettings.ObterValorConexao()))
            {
                try
                {
                    await connection.OpenAsync();
                    var enderecos = (await connection.QueryAsync<Endereco>(QuerysPessoa.ObterEndereco())).ToList();
                    connection.Close();

                    return enderecos;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public async Task<List<Contato>> ObterContatos()
        {
            using (var connection = new MySqlConnection(ConexaoSettings.ObterValorConexao()))
            {
                try
                {
                    await connection.OpenAsync();
                    var contatos = (await connection.QueryAsync<Contato>(QuerysPessoa.ObterContato())).ToList();
                    connection.Close();

                    return contatos;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public async Task<int> CadastrarPessoaFisica(PessoaFisica pessoa)
        {
            using (var connection = new MySqlConnection(ConexaoSettings.ObterValorConexao()))
            {
                try
                {
                    await connection.OpenAsync();

                    var command = new MySqlCommand(QuerysPessoa.Cadastrar(), connection);
                    command.Parameters.AddWithValue("@Nome", pessoa.Nome);
                    command.Parameters.AddWithValue("@Sobrenome", pessoa.Sobrenome);
                    command.Parameters.AddWithValue("@Email", pessoa.Email);
                    command.Parameters.AddWithValue("@TipoDocumento", (int)pessoa.TipoDocumento);
                    command.Parameters.AddWithValue("@Documento", pessoa.Documento);
                    command.Parameters.AddWithValue("@DataNascimento", pessoa.DataNascimento);
                    command.Parameters.AddWithValue("@RG", pessoa.RG);

                    await command.ExecuteNonQueryAsync();

                    int idRegistrado = Convert.ToInt32(command.LastInsertedId);

                    connection.Close();

                    return idRegistrado;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public async Task<Task> CadastrarEndereco(Endereco endereco, int idPessoa)
        {
            using (var connection = new MySqlConnection(ConexaoSettings.ObterValorConexao()))
            {
                try
                {
                    await connection.OpenAsync();
                    await connection.QueryAsync(QuerysEndereco.Cadastrar(idPessoa), endereco);
                    connection.Close();

                    return Task.CompletedTask;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public async Task<Task> CadastrarContato(Contato contato, int idPessoa)
        {
            using (var connection = new MySqlConnection(ConexaoSettings.ObterValorConexao()))
            {
                try
                {
                    await connection.OpenAsync();
                    await connection.QueryAsync(QuerysContato.Cadastrar(idPessoa), contato);
                    connection.Close();

                    return Task.CompletedTask;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
