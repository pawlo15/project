using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Infrastructure.Functions.Command;
using Project.Infrastructure.Models;

namespace Project.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AdministrationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdministrationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Policy = "AccessForWorker")]
        [HttpPost("AddClientToAccount")]
        public async Task<ActionResult<ServiceResponse<string>>> AddClientToAccount()
        {
            var command = new AddClientToAccountCommand();
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [Authorize(Policy = "AccessForWorker")]
        [HttpPost("CreateAccount")]
        public async Task<ActionResult<ServiceResponse<string>>> CreateAccount()
        {
            var command = new CreateAccountCommand();
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [Authorize(Policy = "AccessForWorker")]
        [HttpPost("ChangeAccountStatus")]
        public async Task<ActionResult<ServiceResponse<string>>> ChangeAccountStatus(bool change)
        {
            var command = new ChangeAccountStatusCommand();
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [Authorize(Policy = "AccessForWorker")]
        [HttpPost("ChangeDebitStatus")]
        public async Task<ActionResult<ServiceResponse<string>>> ChangeDebitStatus(bool change)
        {
            var command = new ChangeDebitStatusCommand();
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
