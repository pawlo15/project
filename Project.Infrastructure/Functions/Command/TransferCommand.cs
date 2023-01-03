using MediatR;
using Project.Infrastructure.Models;

namespace Project.Infrastructure.Functions.Command
{
    public class TransferCommand : IRequest<ServiceResponse<string>>
    {
    }
}
