using MediatR;
using Project.Infrastructure.Models;

namespace Project.Infrastructure.Functions.Command
{
    public class TransferCommandHandler : IRequestHandler<TransferCommand, ServiceResponse<string>>
    {
        public Task<ServiceResponse<string>> Handle(TransferCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
