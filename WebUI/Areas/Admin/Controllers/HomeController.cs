using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {

        [HttpGet("AdminUnusedPanel")]
        [Authorize(Roles ="admin")]
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
