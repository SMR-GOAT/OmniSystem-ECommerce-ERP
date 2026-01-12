using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OmniSystem.Data;
using OmniSystem.Models;
using OmniSystem.Services.Interfaces;
using OmniSystem.ViewModels; // تأكد أن كلاس Employee موجود هنا

namespace OmniSystem.Controllers
{
    // حذفنا الـ [ApiController] والـ [Route("api/[controller]")]
 public class EmployeesController : Controller
{
    private readonly IEmployeeService _employeeService;

    public EmployeesController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }


public async Task<IActionResult> Index()
{
    var employees = await _employeeService.GetAllEmployeesAsync();
    return View(employees);
}
    [HttpGet]
    public async Task<IActionResult> CreateEmployee()
    {
        ViewBag.Positions = await _employeeService.GetPositionsAsync();
        return View();
    }

   [HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> CreateEmployee(CreateEmployeeViewModel model)
{
    if (!ModelState.IsValid)
    {
        ViewBag.Positions = await _employeeService.GetPositionsAsync();
        return View(model);
    }

    var result = await _employeeService.CreateEmployeeAsync(model);
    
    if (result.Succeeded) 
    {
        return RedirectToAction("Index"); // إذا نجح سيتوجه لجدول الموظفين
    }

    // إذا فشل Identity (مثلاً الباسورد ضعيفة) ستظهر الأخطاء هنا
    foreach (var error in result.Errors)
        ModelState.AddModelError("", error.Description);

    ViewBag.Positions = await _employeeService.GetPositionsAsync();
    return View(model);
}
}
}