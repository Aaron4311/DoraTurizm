using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WebUI.Models;
using WebUI.Services.Abstract;

namespace WebUI.Services.Concrete
{
    public class TourManager : ITourService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseApiUrl;

        public TourManager(HttpClient httpClient, IOptions<ApiSettings> baseApiUrl)
        {
            _httpClient = httpClient;
            _baseApiUrl = baseApiUrl.Value.BaseApiUrl + "/Tour";
        }

        public async Task<List<TourResponseDto>> GetAll()
        {
            var request = await _httpClient.GetAsync($"{_baseApiUrl}/GetAll");
            if (request.IsSuccessStatusCode)
            {
                var result = await request.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<List<TourResponseDto>>(result);
                return json;
            }
            return null;
        }

        public async Task<TourResponseDto> GetByUrl(string url)
        {
            var request = await _httpClient.GetAsync($"{_baseApiUrl}/GetByUrl/{url}");
            if (request.IsSuccessStatusCode)
            {
                var result = await request.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<TourResponseDto>(result);
                return json;
            }
            return null;
        }

        public async Task<bool> UpdateTour(TourResponseDto tourResponseDto)
        {
            var result = await _httpClient.PutAsJsonAsync($"{_baseApiUrl}/Update", tourResponseDto);
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
