using Microsoft.AspNetCore.Identity;
using OmniSystem.Models;
using OmniSystem.ViewModels;
using OmniSystem.Services.Interfaces;
using OmniSystem.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace OmniSystem.Services;

public class EmployeeService : IEmployeeService
{
    private readonly UserManager<ApplicationUserModel> _userManager;
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public EmployeeService(UserManager<ApplicationUserModel> userManager, ApplicationDbContext context, IMapper mapper)
    {
        _userManager = userManager;
        _context = context;
        _mapper = mapper;
    }

    // تعديل 1: جلب الموظفين مع مناصبهم في استعلام واحد (أداء عالي)
 public async Task<IEnumerable<EmployeeListViewModel>> GetAllEmployeesAsync()
{
    var employees = await _context.Users
        .Include(u => u.Position) // جلب بيانات المنصب
        .Where(u => _context.UserRoles.Any(ur => ur.UserId == u.Id && 
                   _context.Roles.Any(r => r.Id == ur.RoleId && r.Name == "Employee")))
        .ToListAsync();

    return _mapper.Map<IEnumerable<EmployeeListViewModel>>(employees);
}

    public async Task<IEnumerable<Position>> GetPositionsAsync() 
    {
        return await _context.Positions.ToListAsync();
    }

    // تعديل 2: تبسيط عملية الإنشاء (بدون جداول وسيطة)
    public async Task<IdentityResult> CreateEmployeeAsync(CreateEmployeeViewModel model)
    {
        // المابير الحين راح ينقل الـ SelectedPositionId إلى حقل PositionId في اليوزر تلقائياً
        var user = _mapper.Map<ApplicationUserModel>(model);
        
        // إنشاء المستخدم
        var result = await _userManager.CreateAsync(user, model.Password);

        if (!result.Succeeded) return result; 

        try
        {
            // إضافة الدور
            await _userManager.AddToRoleAsync(user, "Employee");
            
            // ما عاد نحتاج نضيف في جدول UserPositions! 
            // الـ PositionId خلاص انحفظ مع اليوزر في خطوة CreateAsync
            
            return IdentityResult.Success;
        }
        catch (Exception ex)
        {
            await _userManager.DeleteAsync(user);
            return IdentityResult.Failed(new IdentityError { 
                Description = "Error assigning role: " + ex.Message 
            });
        }
    }
}