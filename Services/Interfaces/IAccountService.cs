using Microsoft.AspNetCore.Identity;
using MVCCourse.ViewModels;

namespace MVCCourse.Services.Interfaces;

public interface IAccountService
{
    Task<SignInResult> LoginAsync(LoginViewModel model);
    Task LogoutAsync();
}