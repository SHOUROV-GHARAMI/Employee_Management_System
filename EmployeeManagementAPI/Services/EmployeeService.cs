using EmployeeManagementAPI.DTOs;
using EmployeeManagementAPI.Repositories.Interfaces;
using EmployeeManagementAPI.Services.Interfaces;
using EmployeeManagementAPI.Models;
using Microsoft.Extensions.Options;
using System.Globalization;

namespace EmployeeManagementAPI.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly BusinessRulesSettings _businessRules;

    public EmployeeService(IUnitOfWork unitOfWork, IOptions<BusinessRulesSettings> businessRules)
    {
        _unitOfWork = unitOfWork;
        _businessRules = businessRules.Value;
    }

    public async Task<ApiResponse<EmployeeDto>> UpdateEmployeeProfileAsync(int employeeId, UpdateEmployeeDto updateDto)
    {
        try
        {
            var employee = await _unitOfWork.Employees.GetByIdAsync(employeeId);
            
            if (employee == null)
            {
                return ApiResponse<EmployeeDto>.ErrorResponse("Employee not found");
            }

            var codeExists = await _unitOfWork.Employees.EmployeeCodeExistsAsync(updateDto.NewCode, employeeId);
            
            if (codeExists)
            {
                return ApiResponse<EmployeeDto>.ErrorResponse(
                    $"Employee code '{updateDto.NewCode}' already exists for another employee"
                );
            }

            employee.EmployeeName = updateDto.NewName;
            employee.EmployeeCode = updateDto.NewCode;

            _unitOfWork.Employees.Update(employee);
            await _unitOfWork.SaveChangesAsync();

            var updatedEmployee = await _unitOfWork.Employees.GetEmployeeWithSupervisorAsync(employeeId);
            var employeeDto = MapToEmployeeDto(updatedEmployee!);

            return ApiResponse<EmployeeDto>.SuccessResponse(employeeDto, "Employee profile updated successfully");
        }
        catch (Exception ex)
        {
            return ApiResponse<EmployeeDto>.ErrorResponse($"Error updating employee: {ex.Message}");
        }
    }

    public async Task<ApiResponse<EmployeeDto>> GetNthHighestSalaryEmployeeAsync(int rank)
    {
        try
        {
            if (rank < 1)
            {
                return ApiResponse<EmployeeDto>.ErrorResponse("Rank must be greater than 0");
            }

            var employee = await _unitOfWork.Employees.GetNthHighestSalaryEmployeeAsync(rank);
            
            if (employee == null)
            {
                return ApiResponse<EmployeeDto>.ErrorResponse($"No employee found at rank {rank}");
            }

            var employeeDto = MapToEmployeeDto(employee);

            return ApiResponse<EmployeeDto>.SuccessResponse(
                employeeDto, 
                $"Successfully retrieved {GetOrdinal(rank)} highest salary employee"
            );
        }
        catch (Exception ex)
        {
            return ApiResponse<EmployeeDto>.ErrorResponse($"Error retrieving employee: {ex.Message}");
        }
    }

    public async Task<ApiResponse<List<EmployeeDto>>> GetHighEarnersWithPerfectAttendanceAsync(decimal minSalary)
    {
        try
        {
            if (minSalary < 0)
            {
                return ApiResponse<List<EmployeeDto>>.ErrorResponse("Minimum salary must be non-negative");
            }

            var employees = await _unitOfWork.Employees.GetHighEarnersWithPerfectAttendanceAsync(
                minSalary, 
                _businessRules.MaxAllowedAbsencesForPerfectAttendance
            );
            var employeeDtos = employees.Select(MapToEmployeeDto).ToList();

            var attendanceLabel = _businessRules.MaxAllowedAbsencesForPerfectAttendance == 0 
                ? "perfect attendance" 
                : $"excellent attendance (≤{_businessRules.MaxAllowedAbsencesForPerfectAttendance} absences)";

            return ApiResponse<List<EmployeeDto>>.SuccessResponse(
                employeeDtos,
                $"Found {employeeDtos.Count} high earners with {attendanceLabel}"
            );
        }
        catch (Exception ex)
        {
            return ApiResponse<List<EmployeeDto>>.ErrorResponse($"Error retrieving employees: {ex.Message}");
        }
    }

    public async Task<ApiResponse<string>> GetSupervisorHierarchyAsync(int employeeId)
    {
        try
        {
            var hierarchy = await _unitOfWork.Employees.GetSupervisorHierarchyAsync(employeeId);
            
            if (!hierarchy.Any())
            {
                return ApiResponse<string>.ErrorResponse("Employee not found");
            }

            var hierarchyString = string.Join(" → ", hierarchy.Select(e => $"{e.EmployeeName} ({e.EmployeeCode})"));

            return ApiResponse<string>.SuccessResponse(hierarchyString, "Supervisor hierarchy retrieved successfully");
        }
        catch (Exception ex)
        {
            return ApiResponse<string>.ErrorResponse($"Error retrieving hierarchy: {ex.Message}");
        }
    }

    private EmployeeDto MapToEmployeeDto(Models.Employee employee)
    {
        return new EmployeeDto
        {
            EmployeeId = employee.EmployeeId,
            EmployeeName = employee.EmployeeName,
            EmployeeCode = employee.EmployeeCode,
            EmployeeSalary = employee.EmployeeSalary,
            SupervisorId = employee.SupervisorId,
            SupervisorName = employee.Supervisor?.EmployeeName
        };
    }

    private string GetOrdinal(int number)
    {
        if (number <= 0) return number.ToString();

        switch (number % 100)
        {
            case 11:
            case 12:
            case 13:
                return $"{number}th";
        }

        return (number % 10) switch
        {
            1 => $"{number}st",
            2 => $"{number}nd",
            3 => $"{number}rd",
            _ => $"{number}th"
        };
    }
}
