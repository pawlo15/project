using MediatR;
using Project.Infrastructure.Models;

namespace Project.Infrastructure.Functions.Command
{
    public class SendApplicationCommand : IRequest<ServiceResponse<string>>
    {
    }
}
