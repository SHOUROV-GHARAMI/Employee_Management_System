namespace EmployeeManagementAPI.DTOs;

public class EmployeeDto
{
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; } = string.Empty;
    public string EmployeeCode { get; set; } = string.Empty;
    public decimal EmployeeSalary { get; set; }
    public int? SupervisorId { get; set; }
    public string? SupervisorName { get; set; }
}
