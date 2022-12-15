using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    [Authorize]
    [ApiController]
    [Route("controller")]
    public class ClientController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ClientController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        [HttpGet()]
        public async Task<ActionResult> get()
        {
            //var result = await _mediator.Send();
            return Ok();
        }
    }
}
