using EmployeeManagementAPI.Models;

namespace EmployeeManagementAPI.Repositories.Interfaces;

public interface IAttendanceRepository : IGenericRepository<EmployeeAttendance>
{
    Task<IEnumerable<EmployeeAttendance>> GetEmployeeAttendanceByMonthAsync(int employeeId, int month, int year);
    Task<IEnumerable<EmployeeAttendance>> GetAllAttendanceByMonthAsync(int month, int year);
}
