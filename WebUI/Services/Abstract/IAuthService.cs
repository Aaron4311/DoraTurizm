using WebUI.Models;

namespace WebUI.Services.Abstract
{
    public interface IAuthService
    {
        Task<AuthResult> LoginAsync(LoginModelDto loginModelDto);
        Task<RefreshTokenResponseDto> RefreshTokenAsync(string refreshToken);
    }
}
