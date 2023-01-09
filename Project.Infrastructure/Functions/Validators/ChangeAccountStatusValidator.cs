using FluentValidation;
using Project.Infrastructure.Functions.Command;

namespace Project.Infrastructure.Functions.Validators
{
    public class ChangeAccountStatusValidator : AbstractValidator<ChangeAccountStatusCommand>
    {
        public ChangeAccountStatusValidator() 
        {
            string empty = "To pole nie może być puste.";

            RuleFor(x => x.AccountId)
                .NotEmpty()
                .WithMessage(empty);

            RuleFor(x => x.Active)
                .NotEmpty()
                .WithMessage(empty);
        }
    }
}
