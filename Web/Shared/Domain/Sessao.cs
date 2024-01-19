using System.Text.Json;
using Web.Shared.Entities;

namespace Web.Shared.Domain
{
    public static class Sessao
    {
        private static IHttpContextAccessor _httpContextAccessor;

        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public static bool Get()
        {
            var autenticacaoSessao = _httpContextAccessor.HttpContext!.Session.GetString("Autenticacao");
            if (!string.IsNullOrEmpty(autenticacaoSessao))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void Set(UsuarioEntity usuario)
        {
            _httpContextAccessor.HttpContext!.Session.SetString("Autenticacao", JsonSerializer.Serialize(usuario.Email));
        }

        public static void Delete()
        {
            _httpContextAccessor.HttpContext!.Session.Clear();
        }
    }
}
