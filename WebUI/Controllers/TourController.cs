using Microsoft.AspNetCore.Mvc;
using WebUI.Services.Abstract;

namespace WebUI.Controllers
{
    public class TourController : Controller
    {
        private readonly ITourService _tourService;

        public TourController(ITourService tourService)
        {
            _tourService = tourService;
        }

        [HttpGet("turlar")]
        public async Task<IActionResult> Index()
        {
            var tours = await _tourService.GetAllAsync();
            return View(tours);
        }

        [HttpGet("hac")]
        public async Task<IActionResult> Pilgrimage()
        {
            var tours = await _tourService.GetAllAsync();
            return View(tours);
        }
        [HttpGet("umre")]
        public async Task<IActionResult> Umrah()
        {
            return View();
        }

        [HttpGet("Pilgrimage1")]
        public async Task<IActionResult> Pilgrimage1()
        {
            return View();
        }
        [HttpGet("Pilgrimage2")]
        public async Task<IActionResult> Pilgrimage2()
        {
            return View();
        }
    }
}
