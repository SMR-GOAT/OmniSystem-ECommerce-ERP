using Microsoft.AspNetCore.Identity;
using OmniSystem.Models;
using OmniSystem.ViewModels;

namespace OmniSystem.Services.Interfaces;

// في ملف IEmployeeService.cs
public interface IEmployeeService
{
    Task<IEnumerable<Position>> GetPositionsAsync();
    
    // التعديل هنا: يجب أن يرجع ViewModel لأن الـ Service تقوم بعمل Mapping
    Task<IEnumerable<EmployeeListViewModel>> GetAllEmployeesAsync(); 

    Task<IdentityResult> CreateEmployeeAsync(CreateEmployeeViewModel model);
}