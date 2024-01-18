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

        public async Task<Task> Criar(Usuario usuario)
        {
            using (var connection = new MySqlConnection(ConexaoSettings.ObterValorConexao()))
            {
                try
                {
                    await connection.OpenAsync();

                    await connection.QueryAsync(QuerysUsuario.Criar(), usuario);

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
