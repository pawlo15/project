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
            var dbData = await _dataContext.Accounts.Where(a => a.Clients.Any(c => c.ClientId == id)).ToListAsync();
            return dbData;
        }

        public async Task ChangeAccountStatus(int accountId, short isActiv)
        {
            var dbData = await _dataContext.Accounts.FirstOrDefaultAsync(d => d.Id == accountId);
            if (dbData != null)
            {
                _dataContext.Entry(dbData).State = EntityState.Detached;
                dbData.IsActive = isActiv;
                _dataContext.Update(dbData);
                _dataContext.Entry(dbData).State = EntityState.Modified;

                await _dataContext.SaveChangesAsync();
            }
        }

        public async Task ChangeDebitStatus(int accountId, short isActiv)
        {
            var dbData = await _dataContext.Accounts.FirstOrDefaultAsync(d => d.Id == accountId);
            if (dbData != null)
            {
                _dataContext.Entry(dbData).State = EntityState.Detached;
                dbData.HasDebit = isActiv;
                _dataContext.Update(dbData);
                _dataContext.Entry(dbData).State = EntityState.Modified;

                await _dataContext.SaveChangesAsync();
            }
        }

        public async Task<Account> GetAccountByAccountNumber(string accountNumber)
        {
            var dbData = await _dataContext.Accounts.FirstOrDefaultAsync(ac => ac.AccountNumber == accountNumber);
            return dbData;
        }
    }
}
