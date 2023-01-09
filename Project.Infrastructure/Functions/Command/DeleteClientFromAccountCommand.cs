using MediatR;

namespace Project.Infrastructure.Functions.Command
{
    public class DeleteClientFromAccountCommand : IRequest<bool>
    {
        public int ClientId { get; set; }
        public int AccountId { get; set; }
    }
}
