using Microsoft.AspNetCore.Identity;

namespace OmniSystem.Models
{
    public class ApplicationUserModel : IdentityUser
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public decimal Salary { get; set; }
        public string? Address { get; set; }
        public decimal? Rating { get; set; }         
     // في ملف ApplicationUserModel.cs
public int? PositionId { get; set; } // Foreign Key
public virtual Position? Position { get; set; } // Navigation Property
       
    }
}