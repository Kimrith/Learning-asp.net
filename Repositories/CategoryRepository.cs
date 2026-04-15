using Learning.Data;
using Learning.Models;
using Microsoft.EntityFrameworkCore;

namespace Learning.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly LearningDbContext _context;

        public CategoryRepository(LearningDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetByName(string categoryName)
        {
            if (string.IsNullOrEmpty(categoryName))
            {
                return null;
            }

            return await _context.Categories
                .FirstOrDefaultAsync(x => x.NameCategory == categoryName);
        }

        public async Task<Category> AddCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                throw new Exception("Category not found");
            }
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return category;
        }
    }
}