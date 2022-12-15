using Project.Infrastructure.Services.Interfaces.Base;
using Project.Infrastructure.Accessories;

namespace Project.Infrastructure.Models.User
{
    public class Role : IBase
    {
        public int Id { get; set; }
        public Roles Name { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
