using MediatR;
using Project.Infrastructure.Models;

namespace Project.Infrastructure.Functions.Command
{
    public class TransferCommand : IRequest<ServiceResponse<string>>
    {
        public string accountSender { get; set; }
        public string accountReceiver { get; set; }
        public decimal amount { get; set; }
    }
}
