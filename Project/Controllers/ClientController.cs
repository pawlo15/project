using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Infrastructure.DTOs.Client;
using Project.Infrastructure.Functions.Command;
using Project.Infrastructure.Functions.Query;
using Project.Infrastructure.Models;
using Project.Infrastructure.Models.Client;

namespace Project.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ClientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Policy = "AccessForLogClient")]
        [HttpGet("GetClient")]
        public async Task<ActionResult<ServiceResponse<Client>>> GetClient(int id)
        {
            var query = new GetClientQuery();
            query.Id = id;
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [Authorize(Policy = "AccessForLogClient")]
        [HttpGet("GetAllAccounts")]
        public async Task<ActionResult<ServiceResponse<List<Account>>>> GetAllAccounts(int id)
        {
            var query = new GetAccountsQuery();
            query.ClientId = id;
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [Authorize(Policy = "AccessForLogClient")]
        [HttpPost("Application")]
        public async Task<ActionResult<ServiceResponse<string>>> SendApplication()
        {
            var command = new SendApplicationCommand();
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [Authorize(Policy = "AccessForLogClient")]
        [HttpPost("Transfer")]
        public async Task<ActionResult<ServiceResponse<string>>> Transfer()
        {
            var command = new TransferCommand();
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}
