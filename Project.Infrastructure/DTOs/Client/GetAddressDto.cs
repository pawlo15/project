namespace Project.Infrastructure.DTOs.Client
{
    public class GetAddressDto
    {
        public string ApartmentNumber { get; set; }
        public string HouseNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
    }
}
