namespace EmployeeManagementAPI.Models;

public class BusinessRulesSettings
{
    public int MaxAllowedAbsencesForPerfectAttendance { get; set; } = 0;
    public int MinSalaryRank { get; set; } = 1;
    public int MaxSalaryRank { get; set; } = 1000;
    public decimal MinSalaryThreshold { get; set; } = 0;
}
