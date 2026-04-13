using Learning.DTOs;
using Learning.Models;

namespace Learning.Services
{
        public interface IAuthService 
        {
            Task<IEnumerable<AuthsModel>> GetAuthsAsync();
            Task<AuthsModel> CreateAuthAsync(AuthDto auth);
            Task<AuthsModel?> UpdateAuthAsync(AuthsModel auth);
            Task<bool> DeleteAuthAsync(int id);
        }
}
