using MediatR;
using Project.Infrastructure.Models;

namespace Project.Infrastructure.Functions.Command
{
    public class AddClientToAccountCommand : IRequest<ServiceResponse<bool>>
    {
        public int ClientId { get; set; }
        public int AccountId { get; set; }
    }
}
