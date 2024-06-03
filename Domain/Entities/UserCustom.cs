using Microsoft.AspNetCore.Identity;

namespace IdentityStudy.Domain.Entities;

public class UserCustom : IdentityUser
{
    public UserCustom() { }

    private UserCustom(string userName, string email, string password, bool admin, bool emailConfirmed) 
    {
        UserName = userName;
        Email = email;
        PasswordHash = password;
        Admin = admin;
        EmailConfirmed = emailConfirmed;
    }

    public bool Admin { get; private set; }

    public static UserCustom UserCustomCreate(string userName, string email, string password, bool admin, bool emailConfirmed)
    {
        return new UserCustom(userName, email, password, admin, emailConfirmed);
    }
}