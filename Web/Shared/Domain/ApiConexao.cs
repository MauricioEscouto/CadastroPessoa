namespace Web.Shared.Domain
{
    public class ApiConexao
    {
        private const string HOMOLOGACAO = "Homologacao";
        private const string PRODUCAO = "Producao";

        private static IConfiguration _configuration;

        public static void Configure(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static string GetApiUrl()
        {
            string dataBaseAmbiente = _configuration.GetValue<string>("Api:DataBaseEnvironment");
            return dataBaseAmbiente.Equals("1") ? _configuration.GetValue<string>("Api:" + PRODUCAO) : _configuration.GetValue<string>("Api:" + HOMOLOGACAO);
        }
    }
}
