using Microsoft.AspNetCore.Mvc;
using CommBank_Server.Services;
using CommBank_Server.Models;

namespace CommBank_Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService; // Use the Interface here

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<User>> Login(string email, string password)
    {
        var user = await _authService.Login(email, password);
        return user is null ? Unauthorized() : user;
    }
}
