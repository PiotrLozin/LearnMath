using LearnMath.Application.Opinions;
using LearnMath.Application.Opinions.Commands;
using LearnMath.Application.Opinions.Queries;
using LearnMath.Application.Opinions.Requests;
using LearnMath.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LearnMath.Api.Controllers
{
    [ApiController]
    [Route("opinions")]
    public class OpinionsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OpinionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<UserOpinionDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllOpinionsQuery();
            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOpinion([FromBody] CreateOpinionRequest request)
        {
            var command = new CreateOpinionCommand(request);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserOpinionDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType ((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetOpinionByIdQuery()
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
        [ProducesResponseType(typeof(List<UserOpinion>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> EditOpinion([FromBody] EditOpinionRequest request, int id)
        {
            var command = new EditOpinionCommand(request, id);
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
        public async Task<IActionResult> DeleteOpinion(int id)
        {
            var command = new DeleteOpinionCommand(id);
            var result = await _mediator.Send(command);

            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
