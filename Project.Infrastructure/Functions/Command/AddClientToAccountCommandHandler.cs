using MediatR;
using Project.Infrastructure.Models;
using Project.Infrastructure.Services.Interfaces.Base;

namespace Project.Infrastructure.Functions.Command
{
    public class AddClientToAccountCommandHandler : IRequestHandler<AddClientToAccountCommand, ServiceResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddClientToAccountCommandHandler(IUnitOfWork unitOfWork) 
        { 
            _unitOfWork = unitOfWork;
        }
        public async Task<ServiceResponse<bool>> Handle(AddClientToAccountCommand request, CancellationToken cancellationToken)
        {
            var response = new ServiceResponse<bool>();
            var entity = new Models.Client.ClientAccount
            {
                ClientId = request.clientId,
                AccountId = request.accountId
            };
            response.Data = await _unitOfWork.ClientAccountRepository.Add(entity);
            return response;
        }
    }
}
