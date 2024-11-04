using WebUI.Models;

namespace WebUI.Services.Abstract
{
    public interface IMessageService
    {
        Task<List<MessageResponseDto>> GetAllAsync();
        Task<bool> AddAsync(MessageResponseDto messageResponseDto);
    }
}
