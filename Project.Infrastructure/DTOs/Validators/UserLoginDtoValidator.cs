using FluentValidation;
using Project.Infrastructure.DTOs.User;

namespace Project.Infrastructure.DTOs.Validators
{
    public class UserLoginDtoValidator : AbstractValidator<UserLoginDto>
    {
        public UserLoginDtoValidator() 
        {
            string empty = "To pole nie może być puste.";

            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage(empty);

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage(empty);
        }
    }
}
