using FluentValidation;
using Project.Infrastructure.DTOs.User;

namespace Project.Infrastructure.DTOs.Validators
{
    public class UserRegisterDtoValidator : AbstractValidator<UserRegisterDto>
    {
        public UserRegisterDtoValidator() 
        {
            RuleFor(x => x.Login)
                .NotEmpty()
                .WithMessage("To pole nie może być puste.");
        }
    }
}
