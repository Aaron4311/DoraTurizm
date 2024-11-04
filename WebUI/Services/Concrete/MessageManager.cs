using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WebUI.Models;
using WebUI.Services.Abstract;

namespace WebUI.Services.Concrete
{
    public class MessageManager : IMessageService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseApiUrl;

        public MessageManager(HttpClient httpClient, IOptions<ApiSettings> baseApiUrl)
        {
            _httpClient = httpClient;
            _baseApiUrl = baseApiUrl.Value.BaseApiUrl + "/Message";
        }

        public async Task<bool> AddAsync(MessageResponseDto messageResponseDto)
        {
            var request = await _httpClient.PostAsJsonAsync($"{_baseApiUrl}/Add", messageResponseDto);
            if (!request.IsSuccessStatusCode)
            {
                return false;
            }
            return true;
        }

        public async Task<List<MessageResponseDto>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync($"{_baseApiUrl}/GetAll");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<List<MessageResponseDto>>(result);
                return json;
            }
            return null; 
        }
    }
}
