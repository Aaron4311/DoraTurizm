using Microsoft.AspNetCore.Mvc;
using WebUI.Models;
using WebUI.Services.Abstract;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TourController : Controller
    {
        private readonly ITourService _tourService;

        public TourController(ITourService tourService)
        {
            _tourService = tourService;

        }

        [HttpGet("Admin")]
        public async Task<IActionResult> Index()
        {
            var tours = await _tourService.GetAllAsync();
            return View(tours);
        }

        [HttpGet("Admin/Tour/{url}")]
        public async Task<IActionResult> Tour(string url)
        {
            var tour = await _tourService.GetByUrlAsync(url);
            return View(tour);
        }

        [HttpPost("Admin/UpdateTour")]
        public async Task<IActionResult> Tour(TourResponseDto tourResponseDto)
        {
            var result = await _tourService.UpdateTourAsync(tourResponseDto);
            TempData["Success"] = result == true ? "Successful" : "Failure";
            return RedirectToAction("Index");

        }
    }
}
