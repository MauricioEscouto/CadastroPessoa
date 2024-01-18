using Api.Repositories;
using Api.Repositories.Abstractions;
using Api.Services;
using Api.Services.Abstractions;
using Api.Shared.Domain;
using Api.Shared.Domain.Abstractions;

namespace Api.Shared.Modules
{
    public static class InjectionDependecies
    {
        public static IServiceCollection AddDependecies(this IServiceCollection services)
        {
            return services
                .AddHttpContextAccessor()
                .AddSingleton<IHttpContextAccessor, HttpContextAccessor>()
                .AddScoped<IOutputPort, OutputPort>()
                .AddUsuario();
        }

        public static IServiceCollection AddUsuario(this IServiceCollection services)
        {
            return services
                .AddScoped<IUsuarioRepository, UsuarioRepository>()
                .AddScoped<IUsuarioServices, UsuarioServices>();
        }
    }
}
