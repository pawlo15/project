using MediatR;
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
            if (request.amount <= 0)
                return new ServiceResponse<string>();

            var sender = await _unitOfWork.AccountRepository.GetAccountByAccountNumber(request.accountSender);
           
            if((sender == default) || (sender.IsActive == 0))
                return new ServiceResponse<string>();

            if((sender.Balance-request.amount>=0) || ((sender.HasDebit == 1) && (sender.DebitBalance+sender.Balance)-request.amount >=0))
            {
                var receiver = await _unitOfWork.AccountRepository.GetAccountByAccountNumber(request.accountReceiver);

                sender.Balance -= request.amount;
                receiver.Balance += request.amount;

                await _unitOfWork.AccountRepository.Update(receiver);
                await _unitOfWork.AccountRepository.Update(sender);
            }

            return new ServiceResponse<string>();
        }
    }
}
