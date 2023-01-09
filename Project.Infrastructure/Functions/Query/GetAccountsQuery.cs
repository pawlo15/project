using MediatR;
using Project.Infrastructure.DTOs.Account;

namespace Project.Infrastructure.Functions.Query
{
    public class GetAccountsQuery : IRequest<IReadOnlyCollection<GetAccountDto>>
    {
        public int ClientId { get; set; }
    }
}
