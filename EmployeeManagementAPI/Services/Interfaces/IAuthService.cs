using EmployeeManagementAPI.DTOs;

namespace EmployeeManagementAPI.Services.Interfaces;

public interface IAuthService
{
    Task<ApiResponse<AuthResponseDto>> LoginAsync(LoginDto loginDto);
}
