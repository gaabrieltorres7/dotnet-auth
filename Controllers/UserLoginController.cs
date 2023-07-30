using dotnet_auth.Data.Dtos;
using dotnet_auth.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_auth.Controllers;

[ApiController]
[Route("[Controller]")]
public class UserLoginController : ControllerBase
{
    private LoginService _loginService;

    public UserLoginController(LoginService loginService)
    {
        _loginService = loginService;
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginUserDto dto)
    {
        await _loginService.Execute(dto);
        return Ok("User logged in successfully");
    }
}