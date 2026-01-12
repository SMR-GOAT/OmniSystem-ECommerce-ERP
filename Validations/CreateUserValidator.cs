using FluentValidation;
using OmniSystem.ViewModels;

namespace OmniSystem.Validations;

public class CreateUserValidator : AbstractValidator<CreateUserViewModel>
{
   public class CreateEmployeeViewModel
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string ConfirmPassword { get; set; } = null!;
        public int SelectedPositionId { get; set; }
        public decimal Salary { get; set; }
        public double Rating { get; set; }
    }
}