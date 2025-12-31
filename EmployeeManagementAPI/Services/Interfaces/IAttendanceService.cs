using EmployeeManagementAPI.DTOs;

namespace EmployeeManagementAPI.Services.Interfaces;

public interface IAttendanceService
{
    Task<ApiResponse<List<MonthlyReportDto>>> GetMonthlyAttendanceReportAsync(int month, int year);
}
