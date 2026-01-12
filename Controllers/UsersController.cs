using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OmniSystem.Services.Interfaces;
using OmniSystem.ViewModels;

namespace OmniSystem.Controllers
{
    [Authorize(Roles = "SuperAdmin")] 
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            try 
            {
                await _userService.DeleteUserAsync(id);
                return Json(new { success = true, message = "User has been deleted successfully." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        // 1. عرض جدول المستخدمين
        public async Task<IActionResult> Index()
        {
            var userList = await _userService.GetAllUsersWithRolesAsync();
            return View(userList);
        }

        // 2. عرض صفحة إضافة مستخدم جديد (GET)
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // 3. استقبال بيانات المستخدم الجديد ومعالجتها (POST)
        [HttpPost]
        [ValidateAntiForgeryToken] 
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try 
            {
                await _userService.CreateUserAsync(model);
                
                // إضافة رسالة النجاح في TempData
                TempData["SuccessMessage"] = "User created successfully!";
                
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Something went wrong: " + ex.Message);
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null) return NotFound();

            var model = await _userService.GetUserForEditAsync(id);
            
            if (model == null) return NotFound();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            try {
                await _userService.UpdateUserAsync(model);

                // إضافة رسالة النجاح في TempData
                TempData["SuccessMessage"] = "User updated successfully!";

                return RedirectToAction(nameof(Index));
            } catch (Exception ex) {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }
    }
}