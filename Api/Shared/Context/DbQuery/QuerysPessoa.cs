namespace Api.Shared.Context.DbQuery
{
    public static class QuerysPessoa
    {
        public static string ObterPessoa()
        {
            string query = @"
                SELECT * FROM Pessoa;
            ";

            return query;
        }

        public static string ObterEndereco()
        {
            string query = @"
                SELECT * FROM Endereco;
            ";

            return query;
        }

        public static string ObterContato()
        {
            string query = @"
                SELECT * FROM Contato;
            ";

            return query;
        }

        public static string Cadastrar()
        {
            string query = @"
                INSERT INTO Pessoa 
                    (Nome, Sobrenome, Email, TipoDocumento, Documento, DataNascimento, RG) 
                VALUES 
                    (@Nome, @Sobrenome, @Email, @TipoDocumento, @Documento, @DataNascimento, @RG)
            ";

            return query;
        }
    }
}
