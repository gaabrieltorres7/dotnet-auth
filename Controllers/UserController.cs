using dotnet_auth.Data.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_auth.Controllers;

[ApiController]
[Route("[Controller]")]
public class UserController : ControllerBase
{
    [HttpPost]
    public IActionResult RegisterUser(CreateUserDto userDto)
    {
        throw new NotImplementedException();
    }
    
    
}