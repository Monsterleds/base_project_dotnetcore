using curso.api.Models.Course;
using curso.api.Business.Entities;
using curso.api.Business.Repositories;
using curso.api.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Linq;

namespace curso.api.Controllers
{
    [Route("[controller]")]
    [Authorize]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;
        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [SwaggerResponse(statusCode: 201, description: "Curso criado com sucesso", Type = typeof(CourseViewModelInput))]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado")]
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post(CourseViewModelInput courseViewModelInput) {
            Course course = new Course();
            course.Name = courseViewModelInput.Name;
            course.Description = courseViewModelInput.Description;

            var userCode = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            course.UserCode = userCode;

            _courseRepository.Add(course);
            _courseRepository.Commit();

            return Created("", course);
        }
        
        [SwaggerResponse(statusCode: 200, description: "Cursos listados com sucesso", Type = typeof(CourseViewModelInput))]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado")]
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get() {
            var userCode = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);

            var courses = _courseRepository.FindByUserCode(userCode).Select(s => new CourseViewModelInput {
                Name = s.Name,
                Description = s.Description
            });

            return Ok(courses);
        }
    }
}