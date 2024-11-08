using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using System.Net.Http;
using System.Net.Http.Headers;
using WebUI.Models;
using WebUI.Services.Abstract;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly IAuthService _authService;

        public LoginController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet("Login")]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModelDto loginModelDto)
        {
            var rememberMe = HttpContext.Request.Form["RememberMe"].ToString() == "on";
            var result = await _authService.LoginAsync(loginModelDto);
            if (result != null && !string.IsNullOrEmpty(result.AccessToken))
            {
                if (rememberMe)
                {
                    var cookieOptions = new CookieOptions
                    {
                        Expires = DateTime.Now.AddDays(30),
                        HttpOnly = true,
                        Secure = true
                    };
                    Response.Cookies.Append("JWToken", result.AccessToken, cookieOptions);
                    Response.Cookies.Append("RefreshToken", result.RefreshToken, cookieOptions);

                }
                HttpContext.Session.SetString("JWToken", result.AccessToken);
                HttpContext.Session.SetString("RefreshToken", result.RefreshToken);

                return Ok();
            }

            return BadRequest();
        }

        [HttpPost("LogOut")]
        public async Task<IActionResult> LogOut()
        {
            HttpContext.Session.Remove("JWToken");
            if (Request.Cookies.ContainsKey("JWToken"))
            {
                Response.Cookies.Delete("JWToken");
            }
            return RedirectToAction("Index", "Login");
        }

    }
}
