using Microsoft.AspNetCore.Mvc;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace test.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<AuthController> _logger;
    private readonly IConfiguration<AuthController> _config;

    public AuthController(ILogger<AuthController> logger, IConfiguration config)
    {
        _config = config;
        _logger = logger;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel login)
    {
        // Erstat med din egen godkendelses-logik!
        if (login.Username != "username" || login.Password != "password")
        {
            return Unauthorized();
        }
        var token = GenerateJwtToken(login.Username);
        return Ok(new { token });
    }

}
