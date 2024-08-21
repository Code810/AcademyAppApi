using AcademyApp.Application.Dtos.StudentDto;
using AcademyApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AcademyApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpPost]
        public IActionResult Create(StudentCreateDto studentCreateDto)
        {
            return Ok(_studentService.Create(studentCreateDto));
        }
    }
}
