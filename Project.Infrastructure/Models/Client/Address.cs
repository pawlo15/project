using Project.Infrastructure.Services.Interfaces.Base;

namespace Project.Infrastructure.Models.Client
{
    public class Address : IBase
    {
        public int Id { get; set; }
        public string ApartmentNumber { get; set; }
        public string HouseNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public virtual ClientAddress Client { get; set; }
    }
}
