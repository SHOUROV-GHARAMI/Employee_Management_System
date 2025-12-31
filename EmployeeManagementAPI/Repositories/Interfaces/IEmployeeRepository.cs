using EmployeeManagementAPI.Models;

namespace EmployeeManagementAPI.Repositories.Interfaces;

public interface IEmployeeRepository : IGenericRepository<Employee>
{
    Task<Employee?> GetEmployeeWithSupervisorAsync(int employeeId);
    Task<Employee?> GetNthHighestSalaryEmployeeAsync(int rank);
    Task<IEnumerable<Employee>> GetHighEarnersWithPerfectAttendanceAsync(decimal minSalary, int maxAllowedAbsences = 0);
    Task<bool> EmployeeCodeExistsAsync(string code, int? excludeEmployeeId = null);
    Task<List<Employee>> GetSupervisorHierarchyAsync(int employeeId);
}
