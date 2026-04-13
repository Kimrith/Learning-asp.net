using Learning.Data;
using Learning.DTOs;
using Learning.Models;
using Microsoft.EntityFrameworkCore;

namespace Learning.Services
{
    public class CatecoryService : ICatecoryService
    {
        private readonly LearningDbContext _context;

        public CatecoryService(LearningDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Catecory>> GetCatecories()
        {
            return await _context.Catecories.ToListAsync();
        }
        public async Task<Catecory> CreateCatecory(CatecoryDto catecory)
        {
            var newCatecory = new Catecory
            {
                Name = catecory.Name,
                Description = catecory.Description
            };
            _context.Catecories.Add(newCatecory);
            await _context.SaveChangesAsync();
            return newCatecory;
        }
        public async Task<Catecory?> UpdateCatecory(Catecory catecory) 
        { 
           _context.Catecories.Update(catecory);
            await _context.SaveChangesAsync();
            return catecory;
        }
        public async Task<bool> DeleteCatecory(int id) 
        {
            var catecory = await _context.Catecories.FindAsync(id);
            if (catecory == null) return false; 
            _context.Catecories.Remove(catecory);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
