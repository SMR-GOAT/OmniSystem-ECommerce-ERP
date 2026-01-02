using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCCourse.Models;

namespace MVCCourse.Data.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            // 1. قيد الاسم الأول
            builder.Property(u => u.FirstName)
                .IsRequired()             // إلزامي (NOT NULL)
                .HasMaxLength(50)         // أقصى حد 50 حرف (كافي جداً للأسماء)
                .HasColumnType("varchar(50)"); // تحديد النوع في Postgres ليكون دقيقاً

            // 2. قيد الاسم الأخير
            builder.Property(u => u.LastName)
                .IsRequired()             // إلزامي
                .HasMaxLength(50)         // أقصى حد 50 حرف
                .HasColumnType("varchar(50)");

            // 3. قيد اختياري لربط رقم الجوال (إذا أردت جعله فريداً أو إلزامياً)
            builder.Property(u => u.PhoneNumber)
                .HasMaxLength(10);        // تحديد طول رقم الجوال
        }
    }
}