using System.Security.Cryptography;
using System.Text;
using Learning.DTOs;
using Learning.Models;
using Learning.Repositories;
using Learning.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

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

        var token = GenerateToken(user);

        return new AuthResponseDto
        {
            Username = user.Username,
            Email = user.Email,
            Role = user.Role,
            AccessToken = token
        };
    }

    public async Task<AuthResponseDto> Login(LoginDto dto)
    {
        var user = await _repo.GetByUsername(dto.Username);

        if (user == null || !VerifyPassword(dto.Password, user.PasswordHash))
            throw new Exception("Invalid login");

        var token = GenerateToken(user);

        return new AuthResponseDto
        {
            Username = user.Username,
            Email = user.Email,
            Role = user.Role,
            AccessToken = token
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

    private string GenerateToken(AuthUser user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Role),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        // FIXED: Key must be at least 32 characters long for HS256
        var keyString = "this_is_my_super_long_and_secure_secret_key_2026";
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyString));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: "learning-app",
            audience: "learning-app",
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}