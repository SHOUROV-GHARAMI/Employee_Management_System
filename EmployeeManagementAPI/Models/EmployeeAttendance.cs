using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementAPI.Models;

public class EmployeeAttendance
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int EmployeeId { get; set; }

    [Required]
    public DateTime AttendanceDate { get; set; }

    public bool IsPresent { get; set; }

    public bool IsAbsent { get; set; }

    public bool IsOffday { get; set; }

    [ForeignKey("EmployeeId")]
    public Employee Employee { get; set; } = null!;
}
