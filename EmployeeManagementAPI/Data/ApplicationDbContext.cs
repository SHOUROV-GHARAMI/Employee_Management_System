using Microsoft.EntityFrameworkCore;
using EmployeeManagementAPI.Models;

namespace EmployeeManagementAPI.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<EmployeeAttendance> EmployeeAttendances { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId);
            
            entity.HasIndex(e => e.EmployeeCode)
                .IsUnique();

            entity.HasOne(e => e.Supervisor)
                .WithMany(e => e.Subordinates)
                .HasForeignKey(e => e.SupervisorId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasMany(e => e.Attendances)
                .WithOne(a => a.Employee)
                .HasForeignKey(a => a.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<EmployeeAttendance>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasIndex(e => new { e.EmployeeId, e.AttendanceDate })
                .IsUnique();
        });

        SeedData(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().HasData(
            new Employee { EmployeeId = 502036, EmployeeName = "Selim Reja", EmployeeCode = "EMP326", EmployeeSalary = 59000, SupervisorId = null },
            new Employee { EmployeeId = 502030, EmployeeName = "Mehedi Hasan", EmployeeCode = "EMP320", EmployeeSalary = 50000, SupervisorId = 502036 },
            new Employee { EmployeeId = 502031, EmployeeName = "Ashikur Rahman", EmployeeCode = "EMP321", EmployeeSalary = 45000, SupervisorId = 502036 },
            new Employee { EmployeeId = 502032, EmployeeName = "Rakibul Islam", EmployeeCode = "EMP322", EmployeeSalary = 52000, SupervisorId = 502030 },
            new Employee { EmployeeId = 502033, EmployeeName = "Hasan Abdullah", EmployeeCode = "EMP323", EmployeeSalary = 46000, SupervisorId = 502031 },
            new Employee { EmployeeId = 502034, EmployeeName = "Akib Khan", EmployeeCode = "EMP324", EmployeeSalary = 66000, SupervisorId = 502032 },
            new Employee { EmployeeId = 502035, EmployeeName = "Rasel Shikder", EmployeeCode = "EMP325", EmployeeSalary = 53500, SupervisorId = 502033 }
        );

        var startDate = new DateTime(2023, 6, 1);
        var attendanceList = new List<EmployeeAttendance>();
        int attendanceId = 1;

        foreach (var empId in new[] { 502030, 502031, 502032, 502033, 502034, 502035, 502036 })
        {
            bool hasPerfectAttendance = empId == 502030 || empId == 502032 || empId == 502034;
            
            for (int day = 0; day < 30; day++)
            {
                var currentDate = startDate.AddDays(day);
                var isWeekend = currentDate.DayOfWeek == DayOfWeek.Friday || currentDate.DayOfWeek == DayOfWeek.Saturday;
                
                bool isAbsent = false;
                if (!hasPerfectAttendance && !isWeekend)
                {
                    if (day == 5 || day == 15 || day == 25)
                    {
                        isAbsent = true;
                    }
                }
                
                attendanceList.Add(new EmployeeAttendance
                {
                    Id = attendanceId++,
                    EmployeeId = empId,
                    AttendanceDate = currentDate,
                    IsPresent = !isWeekend && !isAbsent,
                    IsAbsent = isAbsent,
                    IsOffday = isWeekend
                });
            }
        }

        modelBuilder.Entity<EmployeeAttendance>().HasData(attendanceList);
    }
}
