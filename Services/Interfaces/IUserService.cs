using Microsoft.AspNetCore.Identity;
using OmniSystem.ViewModels;

namespace OmniSystem.Services.Interfaces;

public interface IUserService
{
    Task CreateUserAsync(CreateUserViewModel model);
    Task<List<UserListViewModel>> GetAllUsersWithRolesAsync();
    
    // التعديل هنا: يجب أن يكون النوع EditUserViewModel
    Task<EditUserViewModel> GetUserForEditAsync(string id); 
    
    Task UpdateUserAsync(EditUserViewModel model);

    Task DeleteUserAsync(string id);
}