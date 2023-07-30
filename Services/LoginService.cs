using AutoMapper;
using dotnet_auth.Data.Dtos;
using dotnet_auth.Models;
using Microsoft.AspNetCore.Identity;

namespace dotnet_auth.Services;

public class LoginService
{
    private SignInManager<User> _signInManager;
    private TokenService _tokenService;

    public LoginService(SignInManager<User> signInManager, TokenService tokenService)
    {
        _signInManager = signInManager;
        _tokenService = tokenService;
    }
    
    public async Task<string> Execute(LoginUserDto dto)
    {
        var result = await _signInManager
            .PasswordSignInAsync(dto.Username, dto.Password, false, false); 
        /*n quero que o cookie persista se o navegador fechar / n quero que a conta bloqueie em caso de falha*/

        if (!result.Succeeded)
        {
            throw new ApplicationException("Unauthenticated user");
        }

        var user = _signInManager
            .UserManager
            .Users
            .FirstOrDefault
                (user => user.NormalizedUserName == dto.Username.ToUpper());

        var token = _tokenService.Execute(user);

        return token;
    }
}