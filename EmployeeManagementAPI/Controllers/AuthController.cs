using Microsoft.AspNetCore.Mvc;
using EmployeeManagementAPI.DTOs;
using EmployeeManagementAPI.Services.Interfaces;

namespace EmployeeManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly ILogger<AuthController> _logger;

    public AuthController(IAuthService authService, ILogger<AuthController> logger)
    {
        _authService = authService;
        _logger = logger;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        _logger.LogInformation("Login attempt for user: {Username}", loginDto.Username);
        
        if (!ModelState.IsValid)
        {
            return BadRequest(ApiResponse<object>.ErrorResponse(
                "Validation failed",
                ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList()
            ));
        }

        var response = await _authService.LoginAsync(loginDto);
        
        if (!response.Success)
            return Unauthorized(response);

        return Ok(response);
    }
}
