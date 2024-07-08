using LearnMath.Application.Teachers;
using LearnMath.Application.Teachers.Requests;
using LearnMath.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LearnMath.Api.Controllers
{
    [ApiController]
    [Route("teachers")]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeachersController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<WeatherForecast>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get()
        {
            var result = await _teacherRepository.GetAll();
            if (!result.Any())
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(List<WeatherForecast>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> SaveTeacher([FromBody] CreateTeacherRequest teacher)
        {
            Address address = new Address(
                Guid.Empty,
                teacher.AddressForm.Street,
                teacher.AddressForm.City,
                teacher.AddressForm.Country,
                teacher.AddressForm.PostCode);

            Teacher teacherEntity = new Teacher(
                Guid.Empty,
                teacher.FirstName,
                teacher.LastName,
                teacher.Profession,
                teacher.Email,
                teacher.Gender,
                teacher.Score,
                teacher.NumberOfOpinions,
                address);

            var result = await _teacherRepository.Save(teacherEntity);

            return Ok(result);
        }
    }
}
