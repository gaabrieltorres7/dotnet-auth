using System.ComponentModel.DataAnnotations;

namespace dotnet_auth.Data.Dtos;

public class CreateUserDto
{
    [Required] public string Username { get; set; }
    [Required] public DateTime DateOfBirth { get; set; }
    [Required] [DataType(DataType.Password)] public string Password { get; set; }
    [Required] [Compare("Password")] public string RePassword { get; set; }
}