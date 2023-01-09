using FluentValidation;
using Project.Infrastructure.Functions.Command;

namespace Project.Infrastructure.Functions.Validators
{
    public class AddClientToAccountValidator : AbstractValidator<AddClientToAccountCommand>
    {
        public AddClientToAccountValidator() 
        {
            string empty = "To pole nie może być puste.";

            RuleFor(x => x.AccountId)
                .NotEmpty()
                .WithMessage(empty);

            RuleFor(x => x.ClientId)
                .NotEmpty()
                .WithMessage(empty);
        }
    }
}
