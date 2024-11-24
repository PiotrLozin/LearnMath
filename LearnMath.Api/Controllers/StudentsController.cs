using LearnMath.Application.Students;
using LearnMath.Application.Students.Queries;
using LearnMath.Application.Teachers;
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
    [Route("students")]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<StudentDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllStudentsQuery();
            var response = await _mediator.Send(query);

            return Ok(response.Students);
        }

        [HttpPost]
        [ProducesResponseType(typeof(List<StudentDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> SaveStudent([FromBody] CreateUserRequest request)
        {
            // Student subject field should be empty.
            request.Subjects = new List<Subject>();

            var command = new CreateUserCommand(request, UserType.Student);
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(StudentDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetStudentByIdQuery()
            {
                Id = id
            };

            var response = await _mediator.Send(query);
            if (response is null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(List<StudentDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> EditStudent([FromBody] EditUserRequest request, int id)
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
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var command = new DeleteUserCommand(id);
            var result = await _mediator.Send(command);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
