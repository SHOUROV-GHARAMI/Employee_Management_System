using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementAPI.Models;

public class Employee
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int EmployeeId { get; set; }

    [Required]
    [MaxLength(200)]
    public string EmployeeName { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string EmployeeCode { get; set; } = string.Empty;

    [Column(TypeName = "decimal(18,2)")]
    public decimal EmployeeSalary { get; set; }

    public int? SupervisorId { get; set; }

    [ForeignKey("SupervisorId")]
    public Employee? Supervisor { get; set; }

    public ICollection<Employee> Subordinates { get; set; } = new List<Employee>();
    
    public ICollection<EmployeeAttendance> Attendances { get; set; } = new List<EmployeeAttendance>();
}
