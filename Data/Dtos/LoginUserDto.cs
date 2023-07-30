using System.ComponentModel.DataAnnotations;

namespace dotnet_auth.Data.Dtos;

public class LoginUserDto
{
    [Required] public string Username { get; set; }
    [Required] public string Password { get; set; }
}