using Learning.DTOs;
using Learning.Models;

namespace Learning.Services
{
    public interface ICatecoryService
    {
        Task<IEnumerable<Catecory>> GetCatecories();
        Task<Catecory> CreateCatecory(CatecoryDto catecory);
        Task<Catecory?> UpdateCatecory(Catecory catecory);
        Task<bool> DeleteCatecory(int id);
    }
}
