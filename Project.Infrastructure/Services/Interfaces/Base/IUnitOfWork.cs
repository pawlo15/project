namespace Project.Infrastructure.Services.Interfaces.Base
{
    public interface IUnitOfWork
    {
        public IAuthenticationService AuthenticationService { get; }
        public Task Save();
    }
}
