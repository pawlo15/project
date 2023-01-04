namespace Project.Infrastructure.Models.Client
{
    public class ClientAccount
    {
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }

        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
        
    }
}
