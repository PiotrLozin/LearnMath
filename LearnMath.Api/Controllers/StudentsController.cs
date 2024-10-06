using LearnMath.Application.Students;
using LearnMath.Application.Teachers;
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

        //[HttpGet]
        //[ProducesResponseType(typeof(List<Student>), (int)HttpStatusCode.OK)]
        //[ProducesResponseType((int)HttpStatusCode.NotFound)]
        //public async Task<IActionResult> Get()
        //{
        //    var result = await _mediator.GetAll();
        //    if (!result.Any())
        //    {
        //        return NotFound();
        //    }

        //    return Ok(result);
        //}

        [HttpPost]
        [ProducesResponseType(typeof(List<Student>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> SaveStudent([FromBody] CreateUserRequest request)
        {
            var command = new CreateUserCommand(request, UserType.Teacher);
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
