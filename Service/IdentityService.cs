using IdentityStudy.Application.DTOs.Request;
using IdentityStudy.Application.DTOs.Response;
using IdentityStudy.Domain.Entities;
using IdentityStudy.Service.Interface;
using Microsoft.AspNetCore.Identity;

namespace IdentityStudy.Service;
public class IdentityService : IIdentityService
{
    private readonly SignInManager<UserCustom> _signInManager;
    private readonly UserManager<UserCustom> _userManager;

    public IdentityService(SignInManager<UserCustom> signInManager, UserManager<UserCustom> userManager)
    {
        _userManager = userManager;
        _signInManager = signInManager; 
    }

    private async Task<object> EnabledUser(UserCustom user, bool succeeded) => succeeded ? await _userManager.SetLockoutEnabledAsync(user, false) : Task.CompletedTask;

    private static UserRegistrationResponse UserReturnWithErrorAdditionIfNecessary(IdentityResult resultCreate)
    {
        var userRegistrationResponse = new UserRegistrationResponse(resultCreate.Succeeded);

        if (!resultCreate.Succeeded && resultCreate.Errors.Any())
            userRegistrationResponse.AddErrors(resultCreate.Errors.Select(d => d.Description));

        return userRegistrationResponse;
    }

    public async Task<UserRegistrationResponse> UserRegistration(UserRegistrationRequest userRegistration)
    {
        var user = UserCustom.UserCustomCreate
            (userRegistration.Email,
            userRegistration.Email,
            userRegistration.Password,
            userRegistration.Admin,
            userRegistration.EmailConfirmed);

        var resultCreate = await _userManager.CreateAsync(user, user.PasswordHash);

        await EnabledUser(user, resultCreate.Succeeded);

        return UserReturnWithErrorAdditionIfNecessary(resultCreate);
    }

    public Task<UserLoginResponse> Login(UserLoginRequest userLogin)
    {
        throw new NotImplementedException();
    }
}

