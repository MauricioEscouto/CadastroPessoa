using Microsoft.AspNetCore.Mvc;

namespace Web.Shared.Domain
{
    public static class HttpRequestApi
    {
        private static HttpClient _httpClient;

        public static void Configure(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public static async Task<IActionResult> GetData(string caminho, object obj)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(caminho, obj);

            string responseData = await response.Content.ReadAsStringAsync();
            var result = new ObjectResult(responseData)
            {
                StatusCode = (int)response.StatusCode
            };

            return result;
        }
    }
}
