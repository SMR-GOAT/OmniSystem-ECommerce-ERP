using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OmniSystem.Models;
using System.Reflection; // مهم لاستخدام ApplyConfigurationsFromAssembly

namespace OmniSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUserModel>
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Position> Positions { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // السطر السحري: يفحص التجميع الحالي (المشروع) ويطبق كل إعدادات
            // IEntityTypeConfiguration<T> الموجودة فيه تلقائيًا.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
