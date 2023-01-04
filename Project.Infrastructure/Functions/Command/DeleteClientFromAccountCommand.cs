using MediatR;

namespace Project.Infrastructure.Functions.Command
{
    public class DeleteClientFromAccountCommand : IRequest<bool>
    {
        public int clientId { get; set; }
        public int accountId { get; set; }
    }
}
