using MyDemo.WebApi.Constants;
using System.ComponentModel.DataAnnotations;

namespace MyDemo.WebApi.Contracts;

public class LoginRequest
{
    [Required]
    [MinLength(1)]
    public string Username { get; init; } = string.Empty;

    [Required]
    [MinLength(7)]
    public string Password { get; init; } = string.Empty;

    [Required]
    [AllowedValues(Roles.Admin, Roles.User, ErrorMessage = $"Claim must be {Roles.Admin} or {Roles.User}.")]
    public string Claim { get; init; } = string.Empty;
}
