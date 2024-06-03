using System.ComponentModel.DataAnnotations;

namespace IdentityStudy.Application.DTOs.Request;

public class UserRegistrationRequest
{
    [Required(ErrorMessage = "The field {0} is required")]
    [EmailAddress(ErrorMessage = "The field {0} is invalid")]
    public string Email { get; set; }

    [Required(ErrorMessage = "The field {0} is required")]
    [StringLength(50, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 6)]
    public string Password { get; set; }

    [Compare(nameof(Password), ErrorMessage = "The passwords must match")]
    public string ConfirmPassword { get; set; }

    public bool Admin { get; set; }
    public bool EmailConfirmed { get; set; }
}

