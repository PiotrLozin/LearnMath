using LearnMath.Application.Teachers;
using LearnMath.Application.Teachers.Dtos;
using LearnMath.Application.Teachers.Queries;
using LearnMath.Application.Users.Commands;
using LearnMath.Application.Users.Requests;
using LearnMath.Domain;
using LearnMath.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LearnMath.Api.Controllers
{
    [ApiController]
    [Route("teachers")]
    public class TeachersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TeachersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<TeacherDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetByFilter([FromQuery]TeacherFilterDto teacherFilterDto)
        {
            var query = new GetTeachersByFilterQuery() 
            {
                Subject = teacherFilterDto.Subject,
                City = teacherFilterDto.City,
                Score = teacherFilterDto.Score,
                Distance = teacherFilterDto.Distance,
            };

            var response = await _mediator.Send(query);

            return Ok(response.Teachers);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TeacherDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetTeacherByIdQuery() 
            {
                Id = id 
            };

            var response = await _mediator.Send(query);
            if(response is null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(List<Teacher>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> SaveTeacher([FromBody] CreateUserRequest request)
        {
            var command = new CreateUserCommand(request, UserType.Teacher);
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(List<Teacher>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> EditTeacher([FromBody] EditUserRequest request, int id)
        {
            var command = new EditUserCommand(request, id);
            var result = await _mediator.Send(command);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var command = new DeleteUserCommand(id);
            var result = await _mediator.Send(command);

            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
