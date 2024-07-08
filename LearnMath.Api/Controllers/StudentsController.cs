using LearnMath.Application.Students;
using LearnMath.Application.Teachers;
using LearnMath.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LearnMath.Api.Controllers
{
    [ApiController]
    [Route("students")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<WeatherForecast>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get()
        {
            var result = await _studentRepository.GetAll();
            if (!result.Any())
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(List<WeatherForecast>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> SaveStudent([FromBody] StudentDto student)
        {
            Student studentEntity = new Student(
                Guid.Empty,
                student.FirstName,
                student.LastName,
                student.Email,
                student.Gender,
                new Address(Guid.Empty, "street", "city", "country", "postCode"));

            var result = await _studentRepository.Save(studentEntity);

            return Ok(result);
        }
    }
}
