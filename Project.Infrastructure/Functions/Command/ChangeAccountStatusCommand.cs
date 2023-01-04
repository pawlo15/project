using MediatR;
using Project.Infrastructure.Models;

namespace Project.Infrastructure.Functions.Command
{
    public class ChangeAccountStatusCommand : IRequest<ServiceResponse<string>>
    {
        public bool active { get; set; }
        public int accountId { get; set; }
    }
}
