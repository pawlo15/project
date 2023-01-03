using MediatR;
using Project.Infrastructure.Models;

namespace Project.Infrastructure.Functions.Command
{
    public class CreateAccountCommand : IRequest<ServiceResponse<string>>
    {
    }
}
