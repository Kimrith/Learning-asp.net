using Learning.DTOs;

namespace Learning.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllAsync();
        Task<CategoryDto?> GetCategoryByName(string categoryName);
        Task<CategoryDto> AddCategory(CreateCategoryDto categoryDto);
        Task<CategoryDto?> UpdateCategory(int id, CategoryDto categoryDto);
        Task<bool> DeleteCategory(int id);
    }
}