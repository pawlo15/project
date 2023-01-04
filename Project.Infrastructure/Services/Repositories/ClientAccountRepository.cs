using Microsoft.EntityFrameworkCore;
using Project.Infrastructure.Data;
using Project.Infrastructure.Models.Client;

namespace Project.Infrastructure.Services.Repositories
{
    public class ClientAccountRepository
    {
        protected readonly DataContext _dataContext;
        public ClientAccountRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> Add(ClientAccount clientAccount)
        {
            _dataContext.ClientAccount.Add(clientAccount);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(ClientAccount clientAccount)
        {
            var dbData = await _dataContext.ClientAccount.FirstOrDefaultAsync(a => a.ClientId == clientAccount.ClientId && a.AccountId == clientAccount.AccountId);
            if (dbData != null)
            {
                _dataContext.ClientAccount.Remove(dbData);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

    }
}
