using Microsoft.AspNetCore.Identity;

namespace MVCCourse.Models
{
    public class ApplicationUser : IdentityUser
    {
        // إضافة الحقول الجديدة
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        
        // ملاحظة: (Email, PhoneNumber, UserName) موجودة تلقائياً في IdentityUser
        // ولا نحتاج لإعادة كتابتها هنا.
    }
}