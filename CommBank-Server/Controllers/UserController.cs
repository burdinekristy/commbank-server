using Microsoft.AspNetCore.Mvc;
using CommBank_Server.Services;
using CommBank_Server.Models;

namespace CommBank_Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUsersService _usersService;

    public UserController(IUsersService usersService)
    {
        _usersService = usersService;
    }

    [HttpGet]
    public async Task<List<User>> Get() => await _usersService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<User>> Get(string id)
    {
        var user = await _usersService.GetAsync(id);
        return user is null ? NotFound() : user;
    }

    [HttpPost]
    public async Task<IActionResult> Post(User newUser)
    {
        await _usersService.CreateAsync(newUser);
        return CreatedAtAction(nameof(Get), new { id = newUser.Id }, newUser);
    }
}
