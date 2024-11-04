using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text.Json;
using WebUI.Models;
using WebUI.Services.Abstract;

namespace WebUI.Services.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseApiUrl;

        public AuthManager(HttpClient httpClient, IOptions<ApiSettings> baseApiUrl)
        {
            _httpClient = httpClient;
            _baseApiUrl = baseApiUrl.Value.BaseApiUrl + "/Auth";
        }

        public async Task<AuthResult> LoginAsync(LoginModelDto loginModelDto)
        {
            var jsonLogin = JsonConvert.SerializeObject(loginModelDto);
            var content = new StringContent(jsonLogin, System.Text.Encoding.UTF8, "application/json");
            var request = await _httpClient.PostAsync($"{_baseApiUrl}/Login", content);
            if (request.IsSuccessStatusCode)
            {
                var requestContent = request.Content.ReadAsStream();
                var authResult = await System.Text.Json.JsonSerializer.DeserializeAsync<AuthResult>(
                                await request.Content.ReadAsStreamAsync(),
                                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                            );
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authResult.Token);
                return authResult;
            }
            return null;
        }
    }
}
