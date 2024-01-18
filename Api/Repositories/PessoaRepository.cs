using Api.Repositories.Abstractions;
using Api.Shared.Context;
using Api.Shared.Context.DbQuery;
using Api.Shared.Entities;
using Api.Shared.Entities.Abstractions;
using Dapper;
using MySql.Data.MySqlClient;

namespace Api.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        public PessoaRepository()
        {
        }

        public async Task<int> CadastrarPessoa(IPessoa pessoa)
        {
            using (var connection = new MySqlConnection(ConexaoSettings.ObterValorConexao()))
            {
                try
                {
                    await connection.OpenAsync();

                    var command = new MySqlCommand(QuerysPessoa.Cadastrar(), connection);
                    command.Parameters.AddWithValue("@Nome", pessoa.Nome);
                    command.Parameters.AddWithValue("@Email", pessoa.Email);
                    command.Parameters.AddWithValue("@TipoDocumento", (int)pessoa.TipoDocumento);
                    command.Parameters.AddWithValue("@Documento", pessoa.Documento);

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
