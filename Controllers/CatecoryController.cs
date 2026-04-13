using Learning.DTOs;
using Learning.Models;
using Learning.Services;
using Microsoft.AspNetCore.Mvc;

namespace Learning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatecoryController : ControllerBase
    {
        private readonly ICatecoryService _catecoryService;

        public CatecoryController(ICatecoryService catecoryService)
        {
            _catecoryService = catecoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Catecory>>> GetCatecories()
        {
            var catecories = await _catecoryService.GetCatecories();
            return Ok(catecories);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCatecory(CatecoryDto catecory)
        {
            var newCatecory = await _catecoryService.CreateCatecory(catecory);
            return Ok(newCatecory);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCatecory(Catecory catecory)
        {
            var updatedCatecory = await _catecoryService.UpdateCatecory(catecory);
            if (updatedCatecory == null) return NotFound();
            return Ok(updatedCatecory);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCatecory(int id)
        {
            var deleteCatecory = await _catecoryService.DeleteCatecory(id);
            if (deleteCatecory == null) return NotFound();
            return NoContent();
        }
    }
}
