
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;
using WebUI.Services.Abstract;

namespace WebUI.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet("Admin/Mesajlar")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("GetMessages")]
        public async Task<IActionResult> GetMessages()
        {
            var result = await _messageService.GetAllAsync();
            return Json(result);
        }


    }
}
