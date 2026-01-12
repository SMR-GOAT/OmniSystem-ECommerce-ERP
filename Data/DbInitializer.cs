using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OmniSystem.Data;
using OmniSystem.Models;

public static class DbInitializer
{
public static async Task SeedData(
    RoleManager<IdentityRole> roleManager, 
    UserManager<ApplicationUserModel> userManager, 
    ApplicationDbContext context) // أضفنا الـ Context هنا للمناصب
{
    try 
    {
        // 1. إضافة الرتب (Roles)
        string[] roleNames = { "SuperAdmin", "Admin", "Employee", "Client" };
        foreach (var roleName in roleNames)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        // 2. إضافة المناصب (Positions) لجدولك الخاص
        string[] positionNames = { "HR", "Marketing", "Driver", "Customer Service", "Designer", "Developer" };
        foreach (var posName in positionNames)
        {
            if (!await context.Positions.AnyAsync(p => p.Name == posName))
            {
                await context.Positions.AddAsync(new Position { Name = posName });
            }
        }
        await context.SaveChangesAsync(); // حفظ المناصب في قاعدة البيانات

        // 3. إنشاء مستخدم SuperAdmin افتراضي
        var adminEmail = "SuperAdmin@smr.com";
        var user = await userManager.FindByEmailAsync(adminEmail);

        if (user == null)
        {
            var newAdmin = new ApplicationUserModel 
            {
                UserName = "SuperAdmin",
                Email = adminEmail,
                FirstName = "Super", 
                LastName = "Admin", 
                PhoneNumber = "+966550563839", 
                EmailConfirmed = true
                // لاحظ: تركنا الـ Positions فارغة للـ Admin لأنه طبيعي ما يكون له منصب وظيفي
            };
            
            var result = await userManager.CreateAsync(newAdmin, "Aa123456!");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(newAdmin, "SuperAdmin");
            }
        }
    }
    catch (Exception ex)
    {
        // تسجيل الخطأ لضمان عدم توقف النظام
        Console.WriteLine($"Seeding Error: {ex.Message}");
    }
}
}