using AutoMapper;
using MediatR;
using Project.Infrastructure.DTOs.Client;
using Project.Infrastructure.Services.Interfaces.Base;

namespace Project.Infrastructure.Functions.Query
{
    public class GetClientQueryHandler : IRequestHandler<GetClientQuery, GetClientDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetClientQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<GetClientDto> Handle(GetClientQuery request, CancellationToken cancellationToken)
        {
            var response = new GetClientDto();
            var client = await _unitOfWork.ClientRepository.Get(request.Id);
            var address = await _unitOfWork.AddressRepository.Get(request.Id);
            response = _mapper.Map<GetClientDto>(client);
            response.Address = _mapper.Map<GetAddressDto>(address);
            return response;
        }
    }
}
