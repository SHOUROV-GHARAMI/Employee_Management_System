using EmployeeManagementAPI.DTOs;
using EmployeeManagementAPI.Repositories.Interfaces;
using EmployeeManagementAPI.Services.Interfaces;
using System.Globalization;

namespace EmployeeManagementAPI.Services;

public class AttendanceService : IAttendanceService
{
    private readonly IUnitOfWork _unitOfWork;

    public AttendanceService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ApiResponse<List<MonthlyReportDto>>> GetMonthlyAttendanceReportAsync(int month, int year)
    {
        try
        {
            if (month < 1 || month > 12)
            {
                return ApiResponse<List<MonthlyReportDto>>.ErrorResponse("Month must be between 1 and 12");
            }

            if (year < 2000 || year > 2100)
            {
                return ApiResponse<List<MonthlyReportDto>>.ErrorResponse("Year must be between 2000 and 2100");
            }

            var attendances = await _unitOfWork.Attendances.GetAllAttendanceByMonthAsync(month, year);
            
            var reports = attendances
                .GroupBy(a => new { a.EmployeeId, a.Employee })
                .Select(g => new MonthlyReportDto
                {
                    EmployeeName = g.Key.Employee.EmployeeName,
                    MonthName = new DateTime(year, month, 1).ToString("MMMM", CultureInfo.InvariantCulture),
                    TotalPresentDays = g.Count(a => a.IsPresent),
                    TotalAbsentDays = g.Count(a => a.IsAbsent),
                    TotalOffdays = g.Count(a => a.IsOffday),
                    CalculatedPayableSalary = CalculatePayableSalary(
                        g.Key.Employee.EmployeeSalary,
                        g.Count(a => a.IsPresent),
                        g.Count(a => a.IsAbsent),
                        g.Count(a => a.IsOffday)
                    )
                })
                .ToList();

            return ApiResponse<List<MonthlyReportDto>>.SuccessResponse(
                reports,
                $"Monthly report for {new DateTime(year, month, 1).ToString("MMMM yyyy")} retrieved successfully"
            );
        }
        catch (Exception ex)
        {
            return ApiResponse<List<MonthlyReportDto>>.ErrorResponse($"Error generating report: {ex.Message}");
        }
    }

    private decimal CalculatePayableSalary(decimal monthlySalary, int presentDays, int absentDays, int offDays)
    {
        // TODO: Consider adding overtime calculation and deductions
        var totalWorkingDays = presentDays + absentDays;
        
        if (totalWorkingDays == 0)
            return 0;

        var perDaySalary = monthlySalary / totalWorkingDays;
        var payableSalary = perDaySalary * presentDays;

        return Math.Round(payableSalary, 2);
    }
}
