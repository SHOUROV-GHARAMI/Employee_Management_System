using Microsoft.EntityFrameworkCore;
using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.Repositories.Interfaces;

namespace EmployeeManagementAPI.Repositories;

public class AttendanceRepository : GenericRepository<EmployeeAttendance>, IAttendanceRepository
{
    public AttendanceRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<EmployeeAttendance>> GetEmployeeAttendanceByMonthAsync(int employeeId, int month, int year)
    {
        return await _context.EmployeeAttendances
            .Where(a => a.EmployeeId == employeeId 
                && a.AttendanceDate.Month == month 
                && a.AttendanceDate.Year == year)
            .OrderBy(a => a.AttendanceDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<EmployeeAttendance>> GetAllAttendanceByMonthAsync(int month, int year)
    {
        return await _context.EmployeeAttendances
            .Include(a => a.Employee)
            .Where(a => a.AttendanceDate.Month == month 
                && a.AttendanceDate.Year == year)
            .OrderBy(a => a.EmployeeId)
            .ThenBy(a => a.AttendanceDate)
            .ToListAsync();
    }
}
