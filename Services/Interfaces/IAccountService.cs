using Microsoft.AspNetCore.Identity;
using OmniSystem.ViewModels;

namespace OmniSystem.Services.Interfaces;

public interface IAccountService
{
    Task<SignInResult> LoginAsync(LoginViewModel model);
    Task LogoutAsync();
}