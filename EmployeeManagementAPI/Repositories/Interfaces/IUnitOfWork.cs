namespace EmployeeManagementAPI.Repositories.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IEmployeeRepository Employees { get; }
    IAttendanceRepository Attendances { get; }
    Task<int> SaveChangesAsync();
}
