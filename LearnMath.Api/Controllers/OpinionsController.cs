using LearnMath.Application.Opinions.Commands;
using LearnMath.Application.Opinions.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public async Task<IActionResult> CreateOpinion([FromBody] CreateOpinionRequest request)
        {
            var command = new CreateOpinionCommand(request);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
