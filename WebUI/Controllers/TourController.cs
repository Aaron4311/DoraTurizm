using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class TourController : Controller
    {
        [HttpGet("turlar")]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet("hac")]
        public async Task<IActionResult> Pilgrimage()
        {
            return View();
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
