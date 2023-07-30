using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using dotnet_auth.Models;
using Microsoft.IdentityModel.Tokens;

namespace dotnet_auth.Services;

public class TokenService
{
    public string Execute(User user)
    {
        var claims = new Claim[]
        {
            new Claim("username", user.UserName),
            new Claim("id", user.Id)
        };

        var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ODN1088da9s0D821d0s97B2092asskFF"));

        var signInCredentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);
        
        var token = new JwtSecurityToken(expires: DateTime.Now.AddMinutes(10), claims: claims, signingCredentials: signInCredentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}