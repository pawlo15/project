using FluentValidation;
using Project.Infrastructure.DTOs.Account;

namespace Project.Infrastructure.DTOs.Validators
{
    public class TransferDtoValidator : AbstractValidator<TransferDto>
    {
        public TransferDtoValidator() 
        {
            string badNumber = "Wprowadź poprawny numer konta.";
            string empty = "To pole nie może być puste.";

            RuleFor(x => x.AccountSender)
                .NotEmpty()
                .WithMessage(empty)

                .Length(26)
                .WithMessage(badNumber);

            RuleFor(x => x.AccountReceiver)
                .NotEmpty()
                .WithMessage(empty)

                .Length(26)
                .WithMessage(badNumber);

            RuleFor(x => x.Amount)
                .NotEmpty()
                .WithMessage(empty)

                .GreaterThanOrEqualTo(0)
                .WithMessage("Kwota przelewu nie może być ujemna.");

            
        }
    }
}
