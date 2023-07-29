using Microsoft.AspNetCore.Identity;

namespace dotnet_auth.Models;

public class User : IdentityUser
{
    public DateTime DateOfBirth { get; set; }

    public User() : base() { }
}