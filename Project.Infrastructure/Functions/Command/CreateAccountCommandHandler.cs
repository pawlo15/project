using MediatR;
using Project.Infrastructure.Models.Client;
using Project.Infrastructure.Services.Interfaces.Base;

namespace Project.Infrastructure.Functions.Command
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, Account>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateAccountCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Account> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var account = new Account{ 
                AccountNumber = AccountNumberGenerator(),
                IsActive = 1,
                Balance = request.Balance,
                DebitBalance = request.DebitBalance,
                HasDebit = request.HasDebit
            };
            var response = await _unitOfWork.AccountRepository.Add(account);
            return response;
        }
        private string AccountNumberGenerator()
        {
            string number = string.Empty;
            for (int i = 0; i < 26; i++)
            {
                number += new Random().Next(0,9).ToString();
            }
            return number;
        }
    }
}
