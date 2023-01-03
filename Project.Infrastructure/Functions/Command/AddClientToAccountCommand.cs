using MediatR;
using Project.Infrastructure.Models;

namespace Project.Infrastructure.Functions.Command
{
    public class AddClientToAccountCommand : IRequest<ServiceResponse<string>>
    {
    }
}
