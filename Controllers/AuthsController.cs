using Learning.DTOs;
using Learning.Models;
using Learning.Services;
using Microsoft.AspNetCore.Mvc;

namespace Learning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthsController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthsModel>>> GetAuths()
        {
            var auths = await _authService.GetAuthsAsync();
            return Ok(auths);
        }

        [HttpPost]
        public async Task<ActionResult<AuthsModel>> PostAuth(AuthDto auth)
        {
            var newAuth = await _authService.CreateAuthAsync(auth);
            return Ok(newAuth);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AuthsModel>> UpdateAuth(AuthsModel auth) 
        { 
            var updatedAuth = await _authService.UpdateAuthAsync(auth);
            return Ok(updatedAuth);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AuthsModel>> DeleteAuth(int id) 
        {
            var authDelete = await _authService.DeleteAuthAsync(id);
            if (!authDelete) return NotFound();
            return NoContent();
        }
    }
}
