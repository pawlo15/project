using MediatR;
using Project.Infrastructure.Accessories;
using Project.Infrastructure.Exceptions;
using Project.Infrastructure.Models;
using Project.Infrastructure.Services.Interfaces.Base;

namespace Project.Infrastructure.Functions.Command
{
    public class TransferCommandHandler : IRequestHandler<TransferCommand, ServiceResponse<string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public TransferCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResponse<string>> Handle(TransferCommand request, CancellationToken cancellationToken)
        {
            if (request.Amount <= 0)
                throw new WrongTransferAmountException(ErrorCode.ERR003);

            var sender = await _unitOfWork.AccountRepository.GetAccountByAccountNumber(request.AccountSender);
            sender.Clients = await _unitOfWork.ClientAccountRepository.GetAllAccountUsers(sender.Id);

            if (sender.Clients.Any(c => c.ClientId == request.ClientId))
            {
                if ((sender == default) || (sender.IsActive == 0))
                    throw new NoActiveAccountException(ErrorCode.ERR004);

                if ((sender.Balance - request.Amount >= 0) || ((sender.HasDebit == 1) && (sender.DebitBalance + sender.Balance) - request.Amount >= 0))
                {
                    var receiver = await _unitOfWork.AccountRepository.GetAccountByAccountNumber(request.AccountReceiver);

                    sender.Balance -= request.Amount;
                    receiver.Balance += request.Amount;

                    await _unitOfWork.AccountRepository.Update(receiver);
                    await _unitOfWork.AccountRepository.Update(sender);
                }
            }
            return new ServiceResponse<string>();
        }
    }
}
