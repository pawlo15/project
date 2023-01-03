using Microsoft.EntityFrameworkCore;
using Project.Infrastructure.Data;
using Project.Infrastructure.Models.Client;
using Project.Infrastructure.Services.Repositories.Base;

namespace Project.Infrastructure.Services.Repositories
{
    public class AccountRepository : GenericRepository<Account>
    {
        public AccountRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public async Task<IReadOnlyCollection<Account>> GetAccountsByClientId(int id)
        {
            var dbData = await _dataContext.Set<Account>().Where(a => a.Clients.Any(c => c.ClientId == id)).ToListAsync();
            return dbData;
        }
    }
}
