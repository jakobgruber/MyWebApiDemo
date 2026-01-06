namespace MyDemo.WebApi.Contracts;

public class LoginRequest
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Claim { get; set; } = string.Empty;
}
