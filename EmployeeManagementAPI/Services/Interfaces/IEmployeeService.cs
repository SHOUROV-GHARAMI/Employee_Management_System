using EmployeeManagementAPI.DTOs;

namespace EmployeeManagementAPI.Services.Interfaces;

public interface IEmployeeService
{
    Task<ApiResponse<EmployeeDto>> UpdateEmployeeProfileAsync(int employeeId, UpdateEmployeeDto updateDto);
    Task<ApiResponse<EmployeeDto>> GetNthHighestSalaryEmployeeAsync(int rank);
    Task<ApiResponse<List<EmployeeDto>>> GetHighEarnersWithPerfectAttendanceAsync(decimal minSalary);
    Task<ApiResponse<string>> GetSupervisorHierarchyAsync(int employeeId);
}
