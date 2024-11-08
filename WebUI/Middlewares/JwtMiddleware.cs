using System.IdentityModel.Tokens.Jwt;
using WebUI.Services.Abstract;

namespace WebUI.Middlewares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IAuthService _authService;

        public JwtMiddleware(RequestDelegate next, IAuthService authService)
        {
            _next = next;
            _authService = authService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Session.GetString("JWToken");

            if (string.IsNullOrEmpty(token))
            {
                context.Request.Cookies.TryGetValue("JWToken", out token);
            }


            if (!string.IsNullOrEmpty(token))
            {

                var isTokenValid = ValidateToken(token);
                if (!isTokenValid)
                {
                    var refreshToken = context.Session.GetString("RefreshToken");
                    if (string.IsNullOrEmpty(refreshToken))
                    {
                        context.Request.Cookies.TryGetValue("RefreshToken", out refreshToken);

                    }
                    if (!string.IsNullOrEmpty(refreshToken))
                    {
                        var refreshTokenResult = await _authService.RefreshTokenAsync(refreshToken);


                        if (refreshTokenResult.Token != null && !string.IsNullOrEmpty(refreshTokenResult.Token))
                        {
                            context.Session.SetString("JWToken", refreshTokenResult.Token);
                            context.Response.Cookies.Append("JWToken", refreshTokenResult.Token, new CookieOptions
                            {
                                HttpOnly = true,
                                Secure = true,
                                Expires = DateTime.Now.AddDays(30)
                            });
                            token = refreshTokenResult.Token;
                            context.Request.Headers.Append("Authorization", $"Bearer {token}");
                        }
                    }
                }
                else
                {
                    context.Request.Headers.Append("Authorization", $"Bearer {token}");
                }
            }
            await _next(context);
        }

        private bool ValidateToken(string token)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(token) as JwtSecurityToken;
                var expirationDate = jsonToken?.ValidTo;
                return expirationDate > DateTime.UtcNow;

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
