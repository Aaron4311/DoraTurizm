namespace WebUI.Models
{
    public class RefreshTokenResponseDto
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
