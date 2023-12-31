using dotnet_auth.Data.Dtos;
using dotnet_auth.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_auth.Controllers;

[ApiController]
[Route("[Controller]")]
public class UserRegisterController : ControllerBase
{
    private RegisterService _registerService;

    public UserRegisterController(RegisterService registerService)
    {
        _registerService = registerService;
    }

    [HttpPost]
    public async Task<IActionResult> Register(CreateUserDto userDto)
    {
        await _registerService.Execute(userDto);
        return Ok("User has been registered");
    }
}