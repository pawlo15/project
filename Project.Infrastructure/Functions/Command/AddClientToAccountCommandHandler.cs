using MediatR;
using Project.Infrastructure.Models;

namespace Project.Infrastructure.Functions.Command
{
    public class AddClientToAccountCommandHandler : IRequestHandler<AddClientToAccountCommand, ServiceResponse<string>>
    {
        public Task<ServiceResponse<string>> Handle(AddClientToAccountCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
