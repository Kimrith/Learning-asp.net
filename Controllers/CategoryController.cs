using Learning.DTOs;
using Learning.Services;
using Microsoft.AspNetCore.Mvc;

namespace Learning.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryDto categoryDto)
        {
            var result = await _service.AddCategory(categoryDto);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(int id, CategoryDto categoryDto)
        {
            var result = await _service.UpdateCategory(id, categoryDto);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _service.DeleteCategory(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
