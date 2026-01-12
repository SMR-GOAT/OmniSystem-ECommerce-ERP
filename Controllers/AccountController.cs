using Microsoft.AspNetCore.Mvc;
using OmniSystem.Services.Interfaces; // استدعاء المجلد الجديد للواجهات
using OmniSystem.ViewModels;

namespace OmniSystem.Controllers;

public class AccountController : Controller
{
    // لم نعد نحتاج SignInManager هنا، استبدلناه بالسيرفس حقنا
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpGet]
    public IActionResult Login() => View();

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            // الكنترولر يطلب من السيرفس تنفيذ الدخول وينتظر النتيجة فقط
            var result = await _accountService.LoginAsync(model);

            if (result.Succeeded)
            {
                // إذا نجح الدخول، توجه للصفحة الرئيسية
                return RedirectToAction("Index", "Home");
            }
            
            // إذا فشل، أظهر رسالة خطأ
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        }
        
        // إذا البيانات غير صالحة (Validation failed)، أرجع لنفس الصفحة
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await _accountService.LogoutAsync();
        return RedirectToAction("Login");
    }
}