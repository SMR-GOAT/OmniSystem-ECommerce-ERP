using FluentValidation;
using MVCCourse.ViewModels;

namespace MVCCourse.Validations
{
    public class LoginValidator : AbstractValidator<LoginViewModel>
    {
        public LoginValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username is required.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required.")
                                    .MinimumLength(6).WithMessage("Password must be at least 6 characters.");
        }
    }
}