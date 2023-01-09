using MediatR;
using Project.Infrastructure.Models;

namespace Project.Infrastructure.Functions.Command
{
    public class TransferCommand : IRequest<ServiceResponse<string>>
    {
        public int ClientId { get; set; }
        public string AccountSender { get; set; }
        public string AccountReceiver { get; set; }
        public decimal Amount { get; set; }
    }
}
