using Microsoft.AspNetCore.Mvc;
using ResultPatternImplementation;
using System.Reflection.Metadata.Ecma335;

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

        return await result.Match<IActionResult>(
            onSuccess: () => { return Ok(result); },
            onFailure: (error) => { return NotFound(result.Error); }
            );

        /* if (result.IsSuccess)
         {
            /* string a = new Error("hata");
             Error b = a;
             a = b;


             return Ok(result);
         }
         return NotFound(result.Error);*/
    }

    [HttpGet]
    public async Task<IActionResult> GetUserById(int id) {
        var result = await _userService.GetUserAsync(id);

        return await result.Match<IActionResult>(
                onSuccess: () => { return Ok(result); },
                onFailure: (error) => { return NotFound(result.Error); }
                );
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

    [HttpPost("CreateUserNew")]
    public async Task<IActionResult> CreateUserNew([FromBody] User user)
    {
        var result = await _userService.CreateUserAsync(user);

        return await result.Match<IActionResult>
            (onSuccess: () => CreatedAtAction(nameof(CreateUser), new { id = user.Id }, result),
             onFailure: (error) => BadRequest(result.Error)
            );
        
        
    }
}