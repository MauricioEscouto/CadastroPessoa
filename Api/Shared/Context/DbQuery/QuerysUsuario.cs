namespace Api.Shared.Context.DbQuery
{
    public static class QuerysUsuario
    {
        public static string Criar()
        {
            string query = $@"
                INSERT INTO Usuario 
                    (Nome, Email, Telefone, Senha) 
                VALUES 
                    (@Nome, @Email, @Telefone, @Senha)
            ";

            return query;
        }
    }
}
