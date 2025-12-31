using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Repositories.Interfaces;

namespace EmployeeManagementAPI.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    public IEmployeeRepository Employees { get; }
    public IAttendanceRepository Attendances { get; }

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        Employees = new EmployeeRepository(_context);
        Attendances = new AttendanceRepository(_context);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
