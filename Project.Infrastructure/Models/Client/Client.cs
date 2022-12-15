using Project.Infrastructure.Services.Interfaces.Base;

namespace Project.Infrastructure.Models.Client
{
    public class Client : IBase
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Pesel { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public virtual ClientAddress Address { get; set; }
        public virtual ICollection<ClientAccount> Accounts { get; set; }
    }
}
