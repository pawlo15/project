using AutoMapper;
using MediatR;
using Project.Infrastructure.DTOs.Account;
using Project.Infrastructure.Models.Client;
using Project.Infrastructure.Services.Interfaces.Base;

namespace Project.Infrastructure.Functions.Query
{
    public class GetAccountsQueryHandler : IRequestHandler<GetAccountsQuery, IReadOnlyCollection<GetAccountDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAccountsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IReadOnlyCollection<GetAccountDto>> Handle(GetAccountsQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.AccountRepository.GetAccountsByClientId(request.ClientId);

            var response = _mapper.Map<IReadOnlyCollection<GetAccountDto>>(result.Select(x => _mapper.Map<GetAccountDto>(x)));
           
            return response;
        }
    }
}
