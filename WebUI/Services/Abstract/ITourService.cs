using WebUI.Models;

namespace WebUI.Services.Abstract
{
    public interface ITourService
    {
        Task<List<TourResponseDto>> GetAllAsync();
        Task<TourResponseDto> GetByUrlAsync(string url);
        Task<bool> UpdateTourAsync(TourResponseDto tourResponseDto);
    }
}
