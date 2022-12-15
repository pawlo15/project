namespace Project.Infrastructure.Models.Client
{
    public class ClientAddress
    {
        public int AddressId { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public Address Address { get; set; }
    }
}
