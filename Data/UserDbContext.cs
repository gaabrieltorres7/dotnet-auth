using dotnet_auth.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace dotnet_auth.Data;

public class UserDbContext : IdentityDbContext<User>
{
    public UserDbContext
        (DbContextOptions<UserDbContext> opts) : base(opts) { }
}