using Microsoft.Extensions.Configuration;
using Project.Infrastructure.Data;
using Project.Infrastructure.Services.Interfaces.Base;

namespace Project.Infrastructure.Services.Repositories.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IConfiguration _configuration;
        private readonly DataContext _dataContext;
        private IAuthenticationService _authenticationService;
        public UnitOfWork(IConfiguration configuration, DataContext dataContext)
        {
            _configuration = configuration;
            _dataContext = dataContext;
        }
        public IAuthenticationService AuthenticationService
        {
            get
            {
                _authenticationService ??= new AuthenticationService(_dataContext, _configuration);
                return _authenticationService;
            }
        }

        public async Task Save()
        {
            await _dataContext.SaveChangesAsync();
        }
    }
}
