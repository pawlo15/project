using Microsoft.Extensions.Configuration;
using Project.Infrastructure.Data;
using Project.Infrastructure.Models.Client;
using Project.Infrastructure.Services.Interfaces.Base;

namespace Project.Infrastructure.Services.Repositories.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IConfiguration _configuration;
        private readonly DataContext _dataContext;
        private IAuthenticationService _authenticationService;
        private GenericRepository<Client> _clientRepository;
        private GenericRepository<Address> _addressRepository;
        private AccountRepository _accountRepository;
        private ClientAccountRepository _clientAccountRepository;
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

        public GenericRepository<Client> ClientRepository
        {
            get
            {
                _clientRepository ??= new GenericRepository<Client>(_dataContext);
                return _clientRepository;
            }
        }
        public GenericRepository<Address> AddressRepository 
        {
            get
            {
                _addressRepository ??= new GenericRepository<Address>(_dataContext);
                return _addressRepository;
            }
        }
        public AccountRepository AccountRepository
        {
            get
            {
                _accountRepository ??= new AccountRepository(_dataContext);
                return _accountRepository;
            }
        }
        public ClientAccountRepository ClientAccountRepository
        {
            get
            {
                _clientAccountRepository ??= new ClientAccountRepository(_dataContext);
                return _clientAccountRepository;    
            }
        }
        public async Task Save()
        {
            await _dataContext.SaveChangesAsync();
        }
    }
}
