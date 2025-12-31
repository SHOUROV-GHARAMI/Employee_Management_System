using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementAPI.DTOs;

public class UpdateEmployeeDto
{
    [Required(ErrorMessage = "Employee name is required")]
    [MaxLength(200, ErrorMessage = "Name cannot exceed 200 characters")]
    public string NewName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Employee code is required")]
    [MaxLength(50, ErrorMessage = "Code cannot exceed 50 characters")]
    public string NewCode { get; set; } = string.Empty;
}
