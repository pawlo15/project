using MediatR;
using Project.Infrastructure.DTOs.Client;

namespace Project.Infrastructure.Functions.Query
{
    public class GetClientQuery : IRequest<GetClientDto>
    {
        public int Id { get; set; }
    }
}
