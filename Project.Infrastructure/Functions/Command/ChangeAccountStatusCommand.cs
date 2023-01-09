using MediatR;
using Project.Infrastructure.Models;

namespace Project.Infrastructure.Functions.Command
{
    public class ChangeAccountStatusCommand : IRequest<ServiceResponse<string>>
    {
        public bool Active { get; set; }
        public int AccountId { get; set; }
    }
}
