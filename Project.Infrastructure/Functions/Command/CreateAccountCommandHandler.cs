using MediatR;
using Project.Infrastructure.Models;

namespace Project.Infrastructure.Functions.Command
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, ServiceResponse<string>>
    {
        public Task<ServiceResponse<string>> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
