using MediatR;
using Project.Infrastructure.Models;

namespace Project.Infrastructure.Functions.Command
{
    public class ChangeAccountStatusCommandHandler : IRequestHandler<ChangeAccountStatusCommand, ServiceResponse<string>>
    {
        public Task<ServiceResponse<string>> Handle(ChangeAccountStatusCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
