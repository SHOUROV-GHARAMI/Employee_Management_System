using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using EmployeeManagementAPI.DTOs;
using EmployeeManagementAPI.Services.Interfaces;

namespace EmployeeManagementAPI.Services;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;

    public AuthService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public Task<ApiResponse<AuthResponseDto>> LoginAsync(LoginDto loginDto)
    {
        try
        {
            // TODO: Replace with database user validation
            if (loginDto.Username == "admin" && loginDto.Password == "admin123")
            {
                var token = GenerateJwtToken(loginDto.Username);
                
                var authResponse = new AuthResponseDto
                {
                    Token = token,
                    Expiration = DateTime.UtcNow.AddHours(24),
                    Username = loginDto.Username
                };

                return Task.FromResult(ApiResponse<AuthResponseDto>.SuccessResponse(authResponse, "Login successful"));
            }

            return Task.FromResult(ApiResponse<AuthResponseDto>.ErrorResponse("Invalid username or password"));
        }
        catch (Exception ex)
        {
            return Task.FromResult(ApiResponse<AuthResponseDto>.ErrorResponse($"Authentication error: {ex.Message}"));
        }
    }

    private string GenerateJwtToken(string username)
    {
        var jwtSettings = _configuration.GetSection("JwtSettings");
        var secretKey = jwtSettings["SecretKey"] ?? throw new InvalidOperationException("JWT SecretKey not configured");
        var issuer = jwtSettings["Issuer"];
        var audience = jwtSettings["Audience"];

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, "Admin"),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddHours(24),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
