using Learning.DTOs;
using Learning.Models;
using Learning.Repositories;

namespace Learning.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;

        public CategoryService(ICategoryRepository repo)
        {
            _repo = repo;
        }

        // GET ALL
        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var categories = await _repo.GetAllAsync();

            return categories.Select(c => new CategoryDto
            {
                Id = c.Id,
                NameCategory = c.NameCategory
            });
        }

        // GET BY NAME
        public async Task<CategoryDto?> GetCategoryByName(string categoryName)
        {
            var category = await _repo.GetByName(categoryName);

            if (category == null)
                return null;

            return new CategoryDto
            {
                NameCategory = category.NameCategory
            };
        }

        // ADD
        public async Task<CategoryDto> AddCategory(CreateCategoryDto categoryDto)
        {
            var category = new Category
            {
                NameCategory = categoryDto.NameCategory
            };

            var addedCategory = await _repo.AddCategory(category);

            return new CategoryDto
            {
                Id = addedCategory.Id,
                NameCategory = addedCategory.NameCategory
            };
        }

        // UPDATE
        public async Task<CategoryDto> UpdateCategory(int id, CategoryDto categoryDto)
        {
            var category = new Category
            {
                Id = id,
                NameCategory = categoryDto.NameCategory
            };

            var updatedCategory = await _repo.UpdateCategory(category);

            return new CategoryDto
            {
                Id = updatedCategory.Id,
                NameCategory = updatedCategory.NameCategory
            };
        }

        // DELETE
        public async Task<bool> DeleteCategory(int id)
        {
            try
            {
                await _repo.DeleteCategory(id);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}