namespace Api.Shared.Context.DbQuery
{
    public static class QuerysPessoa
    {
        public static string Cadastrar()
        {
            string query = @"
                INSERT INTO Pessoa 
                    (Nome, Email, TipoDocumento, Documento) 
                VALUES 
                    (@Nome, @Email, @TipoDocumento, @Documento)
            ";

            return query;
        }
    }
}
