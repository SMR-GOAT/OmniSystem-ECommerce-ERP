using Microsoft.AspNetCore.Identity;
using OmniSystem.Models;
using OmniSystem.ViewModels;
using OmniSystem.Services.Interfaces; // استدعاء الواجهة

namespace OmniSystem.Services;

public class AccountService : IAccountService
{
    private readonly SignInManager<ApplicationUserModel> _signInManager;

    public AccountService(SignInManager<ApplicationUserModel> signInManager)
    {
        _signInManager = signInManager;
    }

    public async Task<SignInResult> LoginAsync(LoginViewModel model)
    {
        return await _signInManager.PasswordSignInAsync(
            model.UserName, 
            model.Password, 
            model.RememberMe, 
            lockoutOnFailure: false);
    }

    public async Task LogoutAsync() => await _signInManager.SignOutAsync();
}