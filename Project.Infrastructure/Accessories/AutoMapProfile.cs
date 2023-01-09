using AutoMapper;
using Project.Infrastructure.DTOs.Account;
using Project.Infrastructure.DTOs.Client;
using Project.Infrastructure.Models.Client;

namespace Project.Infrastructure.Accessories
{
    public class AutoMapProfile : Profile
    {
        public AutoMapProfile() 
        { 
            CreateMap<Client?,GetClientDto>();
            CreateMap<Address?,GetAddressDto>();
            CreateMap<Account?,GetAccountDto>();

            CreateMap<IReadOnlyCollection<Account>?, IReadOnlyCollection<GetAccountDto>>();
        }
    }
}
