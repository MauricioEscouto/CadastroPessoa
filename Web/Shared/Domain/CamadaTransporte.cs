using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Web.Shared.Domain
{
    internal static class CamadaTransporte
    {
        public static T FromJson<T>(this ObjectResult obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            return JsonSerializer.Deserialize<T>(obj.Value!.ToString()!, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = true
            })!;
        }

        public static T FromJson<T>(this string json)
        {
            if (string.IsNullOrEmpty(json))
                throw new ArgumentNullException(nameof(json));

            return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = true
            })!;
        }
    }
}
