namespace Api.Shared.Context
{
    public class ConexaoSettings
    {
        private const string DB_HOMOLOGACAO = "Homologacao";
        private const string DB_PRODUCAO = "Producao";

        private static IConfiguration _configuration;

        public static void Configure(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static string ObterValorConexao()
        {
            string dataBaseAmbiente = _configuration.GetConnectionString("DataBaseEnvironment");

            if (dataBaseAmbiente.Equals("1"))
            {
                return _configuration.GetConnectionString(DB_PRODUCAO);
            }
            else
            {
                return _configuration.GetConnectionString(DB_HOMOLOGACAO);
            }
        }
    }
}
