using Microsoft.AspNetCore.Mvc;
using EcomShop.Core.src.Entity;
using EcomShop.Application.src.DTO;
using EcomShop.Application.src.Service;
using EcomShop.Application.src.ServiceAbstract;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System;

namespace EcomShop.Controllers.src.Authentication;

[ApiController]
[Route("api/v1/auth")]
public class AuthenticationController : ControllerBase
{

  public static User user = new User();
  private readonly IConfiguration _configuration;
  private readonly IAuthenticationService _authenticationService;

  public AuthenticationController(IAuthenticationService authenticationService)
  {
    // _configuration = configuration;
    _authenticationService = authenticationService;
  }

  [HttpPost("register")]
  public async Task<IActionResult> Register([FromBody] UserCreateDto request)
  {
    if (request == null)
    {
      return BadRequest();
    }
    var rs = await _authenticationService.RegisterServiceAsync(request);
    if (!rs)
    {
      return NotFound("Email has registerd!");
    }
    // string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.PasswordHash);
    // user.Email = request.Email;
    // user.PasswordHash = passwordHash;
    return Ok();
  }

  [HttpPost("login")]
  public async Task<ActionResult> Login([FromBody] UserLoginDto request)
  {
    try
    {
      var rs = await _authenticationService.LoginServiceAsync(request);
      return Ok(rs);
    }
    catch (Exception ex)
    {
      // Log the exception for debugging purposes
      Console.WriteLine($"Password is wrong during login: {ex.Message}");

      // Check if the exception message indicates that the password is wrong
      if (ex.Message == "Password is wrong")
      {
        // Return a BadRequest response indicating that the password is wrong
        return BadRequest("Password is wrong.");
      }
      else
      {
        // For other exceptions, return a generic error message
        return StatusCode(500, "An error occurred during login. Please try again later.");
      }
    }
  }


  // private string CreateToken(User user)
  // {
  //   List<Claim> claims = new List<Claim>
  //   {
  //     new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
  //     new Claim(ClaimTypes.Email, user.Email),
  //     new Claim(ClaimTypes.Role, user.Role.ToString())
  //   };

  //   var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JwtSettings:Key").Value!));

  //   // signing credentials
  //   var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

  //   var tokenDescriptor = new SecurityTokenDescriptor
  //   {
  //     Subject = new ClaimsIdentity(claims),
  //     Expires = DateTime.Now.AddDays(1),
  //     SigningCredentials = credentials
  //   };

  //   var tokenHandler = new JwtSecurityTokenHandler();
  //   var token = tokenHandler.CreateToken(tokenDescriptor);
  //   // var jwt = new JwtSecurityTokenHandler().WriteToken(token);

  //   return tokenHandler.WriteToken(token);
  // }
}
