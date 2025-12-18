using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TP6WebAPI.JWTBearerConfig;
using TP6WebAPI.Models.DTO;
using TP6WebAPI.Models.Auth;
using System.Threading.Tasks;


[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly JWTBearerTokenSettings jwt;
    private readonly UserManager<IdentityUser> userManager;

    public AuthController(
        IOptions<JWTBearerTokenSettings> options,
        UserManager<IdentityUser> userManager)
    {
        jwt = options.Value;
        this.userManager = userManager;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterCredentials model)
    {
        var user = new IdentityUser
        {
            UserName = model.Username,
            Email = model.Email
        };

        var result = await userManager.CreateAsync(user, model.Password);
        return result.Succeeded ? Ok("Register Success") : BadRequest(result.Errors);
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginCredentials model)
    {
        var user = await userManager.FindByNameAsync(model.Username);
        if (user == null || !await userManager.CheckPasswordAsync(user, model.Password))
            return Unauthorized();

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Email, user.Email)
        };

        var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwt.SecretKey));
        var token = new JwtSecurityToken(
            jwt.Issuer,
            jwt.Audience,
            claims,
            expires: DateTime.UtcNow.AddSeconds(jwt.ExpireTimeInSeconds),
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
        );

        return Ok(new { Token = new JwtSecurityTokenHandler().WriteToken(token) });
    }
}
