using MediatR;
using Project.Infrastructure.Models.Client;

namespace Project.Infrastructure.Functions.Query
{
    public class GetAccountsQuery : IRequest<Account>
    {
        public int ClientId { get; set; }
    }
}
