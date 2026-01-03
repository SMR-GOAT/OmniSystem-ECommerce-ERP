using MVCCourse.Services.Interfaces;
using MVCCourse.Services;

namespace MVCCourse.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // تسجيل خدمة الحسابات
        services.AddScoped<IAccountService, AccountService>();
        
        // هنا ستضيف أي خدمة جديدة مستقبلاً بنفس الطريقة
        return services;
    }
}