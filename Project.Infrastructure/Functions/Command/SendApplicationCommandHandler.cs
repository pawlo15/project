using MediatR;
using Project.Infrastructure.Models;

namespace Project.Infrastructure.Functions.Command
{
    public class SendApplicationCommandHandler : IRequestHandler<SendApplicationCommand, ServiceResponse<string>>
    {
        public Task<ServiceResponse<string>> Handle(SendApplicationCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
