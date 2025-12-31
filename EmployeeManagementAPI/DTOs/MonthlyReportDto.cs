namespace EmployeeManagementAPI.DTOs;

public class MonthlyReportDto
{
    public string EmployeeName { get; set; } = string.Empty;
    public string MonthName { get; set; } = string.Empty;
    public decimal CalculatedPayableSalary { get; set; }
    public int TotalPresentDays { get; set; }
    public int TotalAbsentDays { get; set; }
    public int TotalOffdays { get; set; }
}
