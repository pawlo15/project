using MediatR;
using Project.Infrastructure.Services.Interfaces.Base;

namespace Project.Infrastructure.Functions.Command
{
    public class DeleteClientFromAccountCommandHandler : IRequestHandler<DeleteClientFromAccountCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteClientFromAccountCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteClientFromAccountCommand request, CancellationToken cancellationToken)
        {
            var entity = new Models.Client.ClientAccount
            {
                ClientId = request.ClientId,
                AccountId = request.AccountId
            };

            await _unitOfWork.ClientAccountRepository.Delete(entity);
            return true;
        }
    }
}
