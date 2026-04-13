using System.Security.Cryptography;
using System.Text;
using Learning.DTOs;
using Learning.Models;
using Learning.Repositories;
using Learning.Services;

public class AuthService : IAuthService
{
    private readonly IAuthRepository _repo;

    public AuthService(IAuthRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<AuthUser>> GetAuthsAsync()
    {
        return await _repo.GetAllAsync();
    }

    public async Task<AuthResponseDto> Register(RegisterDto dto)
    {
        var existing = await _repo.GetByUsername(dto.Username);
        if (existing != null)
            throw new Exception("User already exists");

        var user = new AuthUser
        {
            Username = dto.Username,
            Email = dto.Email,
            Role = "User",
            PasswordHash = HashPassword(dto.Password)
        };

        await _repo.Add(user);

        return new AuthResponseDto
        {
            Username = user.Username,
            Email = user.Email,
            Role = user.Role
        };
    }

    public async Task<AuthResponseDto> Login(LoginDto dto)
    {
        var user = await _repo.GetByUsername(dto.Username);

        if (user == null || !VerifyPassword(dto.Password, user.PasswordHash))
            throw new Exception("Invalid login");

        return new AuthResponseDto
        {
            Username = user.Username,
            Email = user.Email,
            Role = user.Role
        };
    }

    private string HashPassword(string password)
    {
        using var sha = SHA256.Create();
        var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(bytes);
    }

    private bool VerifyPassword(string password, string hash)
    {
        return HashPassword(password) == hash;
    }
}