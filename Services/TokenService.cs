using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using dotnet_auth.Models;
using Microsoft.IdentityModel.Tokens;

namespace dotnet_auth.Services;

public class TokenService
{
    public IConfiguration _configuration { get; set; }

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public string Execute(User user)
    {
        var claims = new Claim[]
        {
            new Claim("username", user.UserName),
            new Claim("id", user.Id),
            new Claim(ClaimTypes.DateOfBirth, user.DateOfBirth.ToString())
        };

        var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SymmetricSecurityKey"]));

        var signInCredentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);
        
        var token = new JwtSecurityToken(expires: DateTime.Now.AddMinutes(10), claims: claims, signingCredentials: signInCredentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}