using IdentityStudy.Application.DTOs.Request;
using IdentityStudy.Application.DTOs.Response;

namespace IdentityStudy.Service.Interface;

public interface IIdentityService
{
    Task<UserRegistrationResponse> UserRegistration(UserRegistrationRequest userRegistration);
    Task<UserLoginResponse> Login(UserLoginRequest userLogin);
}

