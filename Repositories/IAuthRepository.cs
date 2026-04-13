using Learning.Models;

namespace Learning.Repositories
{
    public interface IAuthRepository
    {
        Task<IEnumerable<AuthUser>> GetAllAsync();
        Task<AuthUser> GetByUsername(string username);
        Task<AuthUser> Add(AuthUser user);
    }
}
