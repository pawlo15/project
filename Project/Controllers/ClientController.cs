using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Infrastructure.DTOs.Account;
using Project.Infrastructure.DTOs.Client;
using Project.Infrastructure.Functions.Command;
using Project.Infrastructure.Functions.Query;
using Project.Infrastructure.Models;
using System.Security.Claims;

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
        public async Task<ActionResult<ServiceResponse<GetClientDto>>> GetClient()
        {
            System.Security.Claims.ClaimsIdentity id = User.Identities.First();

            var query = new GetClientQuery { 
                Id = Convert.ToInt32(id.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value) 
            };

            var result = await _mediator.Send(query);

            return Ok(new ServiceResponse<GetClientDto> { Data = result});

        }

        [Authorize(Policy = "AccessForLogClient")]
        [HttpGet("GetAllAccounts")]
        public async Task<ActionResult<ServiceResponse<IReadOnlyCollection<GetAccountDto>>>> GetAllAccounts()
        {
            System.Security.Claims.ClaimsIdentity id = User.Identities.First();

            var query = new GetAccountsQuery { 
                ClientId = Convert.ToInt32(id.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value)
            };

            var result = await _mediator.Send(query);

            return Ok(new ServiceResponse<IReadOnlyCollection<GetAccountDto>> { Data = result });
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
        public async Task<ActionResult<ServiceResponse<string>>> Transfer(TransferDto transfer)
        {
            System.Security.Claims.ClaimsIdentity id = User.Identities.First();
            var command = new TransferCommand
            {
                AccountReceiver = transfer.AccountReceiver,
                AccountSender = transfer.AccountSender,
                Amount = transfer.Amount,
                ClientId = Convert.ToInt32(id.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value)
            };
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}
