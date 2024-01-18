namespace Api.Shared.Context.DbQuery
{
    public static class QuerysContato
    {
        public static string Cadastrar(int IdPessoa)
        {
            string query = $@"
                INSERT INTO Contato 
                    (IdPessoa, Nome, Informacao, TipoContato) 
                VALUES 
                    ({IdPessoa}, @Nome, @Informacao, @TipoContato)
            ";

            return query;
        }
    }
}
