using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class AboutController : Controller
    {
        [HttpGet("hakkimizda")]
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
