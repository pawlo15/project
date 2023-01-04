using Project.Infrastructure.Services.Interfaces.Base;

namespace Project.Infrastructure.Models.Client
{
    public class Account : IBase
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public short IsActive { get; set; }
        public decimal Balance { get; set; }
        public short HasDebit { get; set; }
        public decimal DebitBalance { get; set; }
        public virtual ICollection<ClientAccount> Clients { get; set; }
    }
}
