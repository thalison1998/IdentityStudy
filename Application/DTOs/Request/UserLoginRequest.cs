using System.ComponentModel.DataAnnotations;

namespace IdentityStudy.Application.DTOs.Request;

public class UserLoginRequest
{
    [Required(ErrorMessage = "The field {0} is required")]
    [EmailAddress(ErrorMessage = "The field {0} is invalid")]
    public string Email { get; set; }

    [Required(ErrorMessage = "The field {0} is required")]
    public string Password { get; set; }
}