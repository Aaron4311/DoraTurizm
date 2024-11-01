using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class ContactController : Controller
    {
        [HttpGet("iletisim")]
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
