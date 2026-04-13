using Learning.Data;
using Learning.Models;
using Microsoft.EntityFrameworkCore;

namespace Learning.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly LearningDbContext _context;

        public AuthRepository(LearningDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AuthUser>> GetAllAsync()
        {
            return await _context.Auths.ToListAsync();
        }

        public async Task<AuthUser> GetByUsername(string username)
        {
            return await _context.Auths
                .FirstOrDefaultAsync(x => x.Username == username);
        }

        public async Task<AuthUser> Add(AuthUser user)
        {
            _context.Auths.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
