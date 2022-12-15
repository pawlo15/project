using Project.Infrastructure.Services.Interfaces.Base;

namespace Project.Infrastructure.Models.User
{
    public class User : IBase
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
