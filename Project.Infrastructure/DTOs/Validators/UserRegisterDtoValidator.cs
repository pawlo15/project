using FluentValidation;
using Project.Infrastructure.DTOs.User;

namespace Project.Infrastructure.DTOs.Validators
{
    public class UserRegisterDtoValidator : AbstractValidator<UserRegisterDto>
    {
        public UserRegisterDtoValidator() 
        {
            string empty = "To pole nie może być puste.";

            RuleFor(x => x.Login)
                .NotEmpty()
                .WithMessage(empty)

                .MaximumLength(50)
                .WithMessage("Login nie może być dłuższy niż 50 znaków.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage(empty)

                .MinimumLength(6)
                .WithMessage("Hasło musi mieć więcej niż 5 znaków.");

        }
    }
}
