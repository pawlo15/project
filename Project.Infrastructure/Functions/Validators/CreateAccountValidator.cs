using FluentValidation;
using Project.Infrastructure.Functions.Command;

namespace Project.Infrastructure.Functions.Validators
{
    public class CreateAccountValidator : AbstractValidator<CreateAccountCommand>
    {
        public CreateAccountValidator() 
        {
            string empty = "To pole nie może być puste.";

            RuleFor(x => x.DebitBalance)
                .NotEmpty()
                .WithMessage(empty);

            RuleFor(x => x.Balance)
                .NotEmpty()
                .WithMessage(empty);

            RuleFor(x => x.HasDebit)
                .NotEmpty()
                .WithMessage(empty);
        }
    }
}
