using Web.Services;
using Web.Shared.Domain;
using Web.WebService;

namespace Web.Shared.Modules
{
    public static class InjectionDependecies
    {
        public static IServiceCollection AddDependecies(this IServiceCollection services)
        {
            return services
                .AddHttpContextAccessor()
                .AddSingleton<IHttpContextAccessor, HttpContextAccessor>()
                .AddUsuarioDependency()
                .AddPessoaDependency();
        }

        public static void ConfigureApplication(WebApplication app)
        {
            ApiConexao.Configure(app.Configuration);
            HttpRequestApi.Configure(app.Services.GetRequiredService<IHttpClientFactory>().CreateClient());
            Sessao.Configure(app.Services.GetRequiredService<IHttpContextAccessor>());
        }

        public static IServiceCollection AddUsuarioDependency(this IServiceCollection services)
        {
            return services
                .AddScoped<UsuarioServices>()
                .AddScoped<UsuarioWebService>();
        }

        public static IServiceCollection AddPessoaDependency(this IServiceCollection services)
        {
            return services
                .AddScoped<PessoaServices>()
                .AddScoped<PessoaWebService>();
        }
    }
}
