using Microsoft.AspNetCore.Mvc;
using TaskService.Helpers;

namespace TaskService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{

    private readonly ILogger<AuthController> _logger;

    public AuthController(ILogger<AuthController> logger)
    {
        _logger = logger;
    }

    /*[HttpPost("login")]
    public IActionResult Login(string username)
    {
        var token = JwtTokenGenerator.GenerateToken(username);

        return Ok(new
        {
            Token = token
        });
    }*/

    [HttpPost("login")]
    public IActionResult Login(string username)
    {
        _logger.LogInformation("Login request received for user {Username}", username);

        var token = JwtTokenGenerator.GenerateToken(username);

        _logger.LogInformation("JWT token generated successfully for user {Username}",username);

        return Ok(new
        {
            Token = token
        });
    }
}
