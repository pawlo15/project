using MediatR;
using Project.Infrastructure.Models.Client;

namespace Project.Infrastructure.Functions.Command
{
    public class CreateAccountCommand : IRequest<Account>
    {
        public decimal Balance { get; set; }
        public short HasDebit { get; set; }
        public decimal DebitBalance { get; set; }
    }
}
