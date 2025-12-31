using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{

    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("GetUsers")]
    public async Task<IActionResult> GetUsers()
    {
        var result = await _userService.GetUsersAsync();
        if (result.IsSuccess)
        {
           /* string a = new Error("hata");
            Error b = a;
            a = b;*/


            return Ok(result);
        }
        return NotFound(result.Error);
    }

    [HttpPost("CreateUser")]
    public async Task<IActionResult> CreateUser([FromBody] User user)
    {
        var result = await _userService.CreateUserAsync(user);
        if (result.IsSuccess)
        {
            return CreatedAtAction(nameof(CreateUser), new { id = user.Id }, result);
        }
        return BadRequest(result.Error);
    }
}