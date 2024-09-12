using LearnMath.Application.Teachers;
using LearnMath.Application.Teachers.Commands;
using LearnMath.Application.Teachers.Queries;
using LearnMath.Application.Teachers.Requests;
using LearnMath.Application.Teachers.Requests.Extensions;
using LearnMath.Domain;
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
        [ProducesResponseType(typeof(List<Teacher>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllTeachersQuery();
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
        public async Task<IActionResult> SaveTeacher([FromBody] CreateTeacherRequest request)
        {
            var command = new CreateTeacherCommand(request);
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(List<Teacher>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> EditTeacher([FromBody] EditTeacherRequest request, int id)
        {
            var command = new EditTeacherCommand(request, id);
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
            var command = new DeleteTeacherCommand(id);
            var result = await _mediator.Send(command);

            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
