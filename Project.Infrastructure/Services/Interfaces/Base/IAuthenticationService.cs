using Project.Infrastructure.Models;
using Project.Infrastructure.Models.User;

namespace Project.Infrastructure.Services.Interfaces.Base
{
    public interface IAuthenticationService
    {
        Task<ServiceResponse<int>> Register(User user, string password);
        Task<ServiceResponse<string>> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}
