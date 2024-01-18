namespace Api.Shared.Context.DbQuery
{
    public static class QuerysEndereco
    {
        public static string Cadastrar(int IdPessoa)
        {
            string query = $@"
                INSERT INTO Endereco 
                    (IdPessoa, Logradouro, Numero, Cep, Complemento, Cidade, Estado) 
                VALUES 
                    ({IdPessoa}, @Logradouro, @Numero, @Cep, @Complemento, @Cidade, @Estado)
            ";

            return query;
        }
    }
}
