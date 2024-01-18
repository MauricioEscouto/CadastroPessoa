using Api.Repositories.Abstractions;
using Api.Shared.Context;
using Api.Shared.Context.DbQuery;
using Api.Shared.Entities;
using Dapper;
using MySql.Data.MySqlClient;

namespace Api.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public UsuarioRepository()
        {

        }

        public async Task<Task> Cadastrar(Usuario usuario)
        {
            using (var connection = new MySqlConnection(ConexaoSettings.ObterValorConexao()))
            {
                try
                {
                    await connection.OpenAsync();

                    await connection.QueryAsync(QuerysUsuario.Cadastrar(), usuario);

                    return Task.CompletedTask;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public async Task<Usuario?> Logar(Usuario usuario)
        {
            using (var connection = new MySqlConnection(ConexaoSettings.ObterValorConexao()))
            {
                try
                {
                    await connection.OpenAsync();

                    Usuario? usuarioObtido = await connection.QueryFirstOrDefaultAsync<Usuario?>(QuerysUsuario.Logar(), usuario);

                    return usuarioObtido;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
