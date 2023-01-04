using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Infrastructure.Functions.Command;
using Project.Infrastructure.Models;
using Project.Infrastructure.Models.Client;

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
        public async Task<ActionResult<ServiceResponse<string>>> AddClientToAccount(AddClientToAccountCommand clientAccount)
        {
            var result = await _mediator.Send(clientAccount);
            return Ok(result);
        }

        [Authorize(Policy = "AccessForWorker")]
        [HttpPost("DeleteClientFromAccount")]
        public async Task<ActionResult<ServiceResponse<string>>> DeleteClientFromAccount(DeleteClientFromAccountCommand clientAccount)
        {
            var result = await _mediator.Send(clientAccount);
            return Ok(result);
        }

        [Authorize(Policy = "AccessForWorker")]
        [HttpPost("CreateAccount")]
        public async Task<ActionResult<ServiceResponse<Account>>> CreateAccount(CreateAccountCommand createAccount)
        {
            var result = await _mediator.Send(createAccount);
            return Ok(result);
        }

        [Authorize(Policy = "AccessForWorker")]
        [HttpPost("ChangeAccountStatus")]
        public async Task<ActionResult<ServiceResponse<string>>> ChangeAccountStatus(ChangeAccountStatusCommand change)
        {
            var result = await _mediator.Send(change);
            return Ok(result);
        }

        [Authorize(Policy = "AccessForWorker")]
        [HttpPost("ChangeDebitStatus")]
        public async Task<ActionResult<ServiceResponse<string>>> ChangeDebitStatus(ChangeDebitStatusCommand change)
        {
            var result = await _mediator.Send(change);
            return Ok(result);
        }
    }
}
