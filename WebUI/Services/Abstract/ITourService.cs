using WebUI.Models;

namespace WebUI.Services.Abstract
{
    public interface ITourService
    {
        Task<List<TourResponseDto>> GetAll();
        Task<TourResponseDto> GetByUrl(string url);
        Task<bool> UpdateTour(TourResponseDto tourResponseDto);
    }
}
