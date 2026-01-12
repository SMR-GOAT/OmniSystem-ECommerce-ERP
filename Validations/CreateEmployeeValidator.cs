using FluentValidation;
using OmniSystem.ViewModels;

namespace OmniSystem.Validations;
public class CreateEmployeeValidator : AbstractValidator<CreateEmployeeViewModel>
    {
        public CreateEmployeeValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First Name is required")
                .MaximumLength(50);

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last Name is required");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("A valid email is required");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Mobile number is required")
                .Matches(@"^\d{10}$").WithMessage("Phone number must be exactly 10 digits");

            RuleFor(x => x.UserName)
                .NotEmpty()
                .MinimumLength(5)
                .Matches(@"^[a-zA-Z0-9._]+$").WithMessage("Only letters, numbers, dots and underscores are allowed");

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(6).WithMessage("Password must be at least 6 characters");

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password).WithMessage("Passwords do not match");

            RuleFor(x => x.SelectedPositionId)
                .GreaterThan(0).WithMessage("Please select a position");

            RuleFor(x => x.Salary)
                .GreaterThan(0).WithMessage("Salary must be positive");

            RuleFor(x => x.Rating)
                .InclusiveBetween(0, 5).WithMessage("Rating must be between 0 and 5");
        }
    }
