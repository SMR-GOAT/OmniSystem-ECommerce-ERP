using System.ComponentModel.DataAnnotations;

namespace OmniSystem.ViewModels
{
    public class CreateEmployeeViewModel
    {
        [Required(ErrorMessage = "First Name is required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Last Name is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;

        [Required, EmailAddress]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Mobile number is required")]
    [Phone(ErrorMessage = "Invalid phone number format")]
    [Display(Name = "Mobile Number")]
    public string PhoneNumber { get; set; } = null!; // إضافة رقم الجوال

    [Required]
    [MinLength(5, ErrorMessage = "Username must be at least 5 characters")]
    [RegularExpression(@"^[a-zA-Z0-9._]+$", ErrorMessage = "Only letters, numbers, dots and underscores are allowed")]
    public string UserName { get; set; } = null!; // الآن أصبح مستقلاً

        
        [Required, DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required, Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;

        [Required(ErrorMessage = "Please select a position")]
        public int SelectedPositionId { get; set; }

        public string Role { get; set; } = "Employee";
        public decimal Salary { get; set; }
        public decimal Rating { get; set; }
    }
}