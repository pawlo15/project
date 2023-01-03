using Project.Infrastructure.Models.Client;

namespace Project.Infrastructure.DTOs.Client
{
    public class GetClientDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Pesel { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public GetAddressDto Address { get; set; }
    }
}
