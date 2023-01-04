using Project.Infrastructure.Models.Client;
using Project.Infrastructure.Services.Repositories;
using Project.Infrastructure.Services.Repositories.Base;

namespace Project.Infrastructure.Services.Interfaces.Base
{
    public interface IUnitOfWork
    {
        public IAuthenticationService AuthenticationService { get; }
        public GenericRepository<Client> ClientRepository { get; }
        public GenericRepository<Address> AddressRepository { get; }
        public AccountRepository AccountRepository { get; }
        public ClientAccountRepository ClientAccountRepository { get; }
        public Task Save();
    }
}
