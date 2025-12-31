using Microsoft.EntityFrameworkCore;
using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.Repositories.Interfaces;

namespace EmployeeManagementAPI.Repositories;

public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<Employee?> GetEmployeeWithSupervisorAsync(int employeeId)
    {
        return await _context.Employees
            .Include(e => e.Supervisor)
            .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
    }

    public async Task<Employee?> GetNthHighestSalaryEmployeeAsync(int rank)
    {
        return await _context.Employees
            .OrderByDescending(e => e.EmployeeSalary)
            .Skip(rank - 1)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Employee>> GetHighEarnersWithPerfectAttendanceAsync(decimal minSalary, int maxAllowedAbsences = 0)
    {
        var employeesWithNoAbsences = await _context.Employees
            .Include(e => e.Attendances)
            .Where(e => e.EmployeeSalary >= minSalary)
            .Where(e => e.Attendances.Count(a => a.IsAbsent) <= maxAllowedAbsences)
            .OrderByDescending(e => e.EmployeeSalary)
            .ToListAsync();

        return employeesWithNoAbsences;
    }

    public async Task<bool> EmployeeCodeExistsAsync(string code, int? excludeEmployeeId = null)
    {
        var query = _context.Employees.Where(e => e.EmployeeCode == code);
        
        if (excludeEmployeeId.HasValue)
        {
            query = query.Where(e => e.EmployeeId != excludeEmployeeId.Value);
        }

        return await query.AnyAsync();
    }

    public async Task<List<Employee>> GetSupervisorHierarchyAsync(int employeeId)
    {
        var hierarchy = new List<Employee>();
        var currentEmployee = await GetEmployeeWithSupervisorAsync(employeeId);

        while (currentEmployee != null)
        {
            hierarchy.Add(currentEmployee);
            
            if (currentEmployee.SupervisorId == null)
                break;

            currentEmployee = await GetEmployeeWithSupervisorAsync(currentEmployee.SupervisorId.Value);
        }

        return hierarchy;
    }
}
