using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagementAPI.DTOs;
using EmployeeManagementAPI.Services.Interfaces;

namespace EmployeeManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class AttendanceController : ControllerBase
{
    private readonly IAttendanceService _attendanceService;

    public AttendanceController(IAttendanceService attendanceService)
    {
        _attendanceService = attendanceService;
    }

    [HttpGet("monthly-report")]
    public async Task<IActionResult> GetMonthlyReport([FromQuery] int month, [FromQuery] int year)
    {
        var response = await _attendanceService.GetMonthlyAttendanceReportAsync(month, year);
        
        if (!response.Success)
            return BadRequest(response);

        return Ok(response);
    }
}
