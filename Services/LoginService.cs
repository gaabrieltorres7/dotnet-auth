using AutoMapper;
using dotnet_auth.Data.Dtos;
using dotnet_auth.Models;
using Microsoft.AspNetCore.Identity;

namespace dotnet_auth.Services;

public class LoginService
{
    private IMapper _mapper;
    private SignInManager<User> _signInManager;

    public LoginService(SignInManager<User> signInManager, IMapper mapper)
    {
        _signInManager = signInManager;
        _mapper = mapper;

    }
    
    public async Task Execute(LoginUserDto dto)
    {
        var result = await _signInManager
            .PasswordSignInAsync(dto.Username, dto.Password, false, false); 
        /*n quero que o cookie persista se o navegador fechar / n quero que a conta bloqueie em caso de falha*/

        if (!result.Succeeded)
        {
            throw new ApplicationException("Unauthenticated user");
        }
    }
}