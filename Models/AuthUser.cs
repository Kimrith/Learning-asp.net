namespace Learning.Models
{
    public class AuthUser
    {
        public int Id { get; set; }   // ✅ PRIMARY KEY
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = "User";
        public string RefreshToken { get; set; } = string.Empty;
    }
}
