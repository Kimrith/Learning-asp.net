using Learning.DTOs;
using Learning.Models;
using Learning.Services;
using Microsoft.AspNetCore.Mvc;

namespace Learning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            var courses = await _courseService.GetAllCoursesAsync();
            return Ok(courses);
        }

        [HttpPost]
        public async Task<ActionResult<Course>> PostCourse(CourseDto courseDto)
        {
            var course = await _courseService.CreateCourseAsync(courseDto);
            return Ok(course);
        }

        [HttpPut]
        public async Task<ActionResult<Course>> UpdateCourse(Course course)
        {
            var updatedCourse = await _courseService.UpdateCourseAsync(course);
            return Ok(updatedCourse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var result = await _courseService.DeleteCourseAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}