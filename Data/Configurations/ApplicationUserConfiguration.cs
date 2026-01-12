using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmniSystem.Models;

namespace OmniSystem.Data.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUserModel>
    {
       public void Configure(EntityTypeBuilder<ApplicationUserModel> builder)
{
    // 1. قيد الاسم الأول والأخير
    builder.Property(u => u.FirstName)
        .IsRequired()
        .HasMaxLength(50)
        .HasColumnType("varchar(50)");

    builder.Property(u => u.LastName)
        .IsRequired()
        .HasMaxLength(50)
        .HasColumnType("varchar(50)");

    // 2. قيد الراتب والعنوان
    builder.Property(u => u.Salary)
        .HasColumnType("decimal(18,2)")
        .HasDefaultValue(0);

    builder.Property(u => u.Address)
        .HasMaxLength(200);

    // 3. إعداد العلاقة مع المنصب (هذا هو الجزء الأهم للربط)
    builder.HasOne(u => u.Position)
        .WithMany() 
        .HasForeignKey(u => u.PositionId)
        .OnDelete(DeleteBehavior.Restrict); 
}
    }
}