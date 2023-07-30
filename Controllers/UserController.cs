using dotnet_auth.Data.Dtos;
using dotnet_auth.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_auth.Controllers;

[ApiController]
[Route("[Controller]")]
public class UserController : ControllerBase
{
    private RegisterService _registerService;

    public UserController(RegisterService registerService)
    {
        _registerService = registerService;
    }

    [HttpPost]
    public async Task<IActionResult> RegisterUser(CreateUserDto userDto)
    {
        await _registerService.Register(userDto);
        return Ok("User has been registered");
    }
}