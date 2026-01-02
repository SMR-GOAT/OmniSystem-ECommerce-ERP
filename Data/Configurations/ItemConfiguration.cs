using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCCourse.Models; // تأكد من أن مساحة الاسم هذه صحيحة

namespace TestCoreApp.Data.Configurations
{
    public class ItemsConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(i => i.Price)
                   .IsRequired()
                   .HasColumnType("decimal(18, 2)");

            // **السطر المصحح لـ PostgreSQL:**
            builder.Property(i => i.CreatedDate)
                   .HasDefaultValueSql("NOW()") // يستخدم NOW() المتوافقة مع PostgreSQL
                   .ValueGeneratedOnAdd();
            
            builder.ToTable("Item");
        }
    }
}
