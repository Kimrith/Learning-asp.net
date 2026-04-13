using Learning.DTOs;
using Learning.Models;

namespace Learning.Services
{
    public interface IAuthService
    {
        Task<IEnumerable<AuthUser>> GetAuthsAsync();
        Task<AuthResponseDto> Register(RegisterDto dto);
        Task<AuthResponseDto> Login(LoginDto dto);
    }
}
