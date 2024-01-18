namespace Api.Shared.Context.DbQuery
{
    public static class QuerysUsuario
    {
        public static string Cadastrar()
        {
            string query = $@"
                INSERT INTO Usuario 
                    (Nome, Email, Telefone, Senha) 
                VALUES 
                    (@Nome, @Email, @Telefone, @Senha)
            ";

            return query;
        }

        public static string Logar()
        {
            string query = @"
                SELECT 
                    Id, Nome, Email, Telefone, Senha
                FROM 
                    Usuario 
                WHERE 
                    Email = @Email
            ";

            return query;
        }
    }
}
