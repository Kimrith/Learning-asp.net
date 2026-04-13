using Learning.Data;
using Learning.DTOs;
using Learning.Models;
using Microsoft.EntityFrameworkCore;

namespace Learning.Services
{
    public class Auths : IAuthService
    {
        private readonly LearningDbContext _context;

        public Auths(LearningDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AuthsModel>> GetAuthsAsync()
        {
            return await _context.Auths.ToListAsync();
        }

        public async Task<AuthsModel> CreateAuthAsync(AuthDto auth)
        {
            var auths = new AuthsModel
            {
                Username = auth.Username,
                Password = auth.Password,
                Email = auth.Email,
                Role = auth.Role
            };
            _context.Auths.Add(auths);
            await _context.SaveChangesAsync();
            return auths;
        }

        public async Task<AuthsModel?> UpdateAuthAsync(AuthsModel auth)
        {
            _context.Auths.Update(auth);
            await _context.SaveChangesAsync();
            return auth;
        }

        public async Task<bool> DeleteAuthAsync(int id)
        {
            var auth = await _context.Auths.FindAsync(id);
            if (auth == null) return false;
            _context.Auths.Remove(auth);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
