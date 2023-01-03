using AutoMapper;
using MediatR;
using Project.Infrastructure.Models.Client;
using Project.Infrastructure.Services.Interfaces.Base;

namespace Project.Infrastructure.Functions.Query
{
    public class GetAccountsQueryHandler : IRequestHandler<GetAccountsQuery, Account>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAccountsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Account> Handle(GetAccountsQuery request, CancellationToken cancellationToken)
        {
            var response = new Account();
            var result = _unitOfWork.AccountRepository.GetAccountsByClientId(request.ClientId);

            return response;
        }
    }
}
