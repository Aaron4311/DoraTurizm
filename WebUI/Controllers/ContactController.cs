using Microsoft.AspNetCore.Mvc;
using WebUI.Models;
using WebUI.Services.Abstract;

namespace WebUI.Controllers
{
    public class ContactController : Controller
    {

        private IMessageService _messageService;
        public ContactController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet("iletisim")]
        public async Task<IActionResult> Index()
        {
            return View();
        }


        [HttpPost("SendMessage")]
        public async Task<IActionResult> SendMessage([FromBody] MessageResponseDto messageResponseDto)
        {
            if (messageResponseDto == null)
            {
                return BadRequest("Bir Hata Oluştu. Lütfen Daha Sonra Tekrar Deneyiniz.");
            }

            await _messageService.AddAsync(messageResponseDto);
            return Ok(); 
        }


    }
}
