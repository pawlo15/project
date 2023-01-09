using MediatR;
using Project.Infrastructure.Models;
using Project.Infrastructure.Services.Interfaces.Base;

namespace Project.Infrastructure.Functions.Command
{
    public class ChangeAccountStatusCommandHandler : IRequestHandler<ChangeAccountStatusCommand, ServiceResponse<string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ChangeAccountStatusCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResponse<string>> Handle(ChangeAccountStatusCommand request, CancellationToken cancellationToken)
        {
            short status;
            if (request.Active)
                status = 1;
            else
                status = 0;

            await _unitOfWork.AccountRepository.ChangeAccountStatus(request.AccountId, status);

            return new ServiceResponse<string>();
        }
    }
}
