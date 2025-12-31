using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using EmployeeManagementAPI.DTOs;
using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.Services.Interfaces;

namespace EmployeeManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeService _employeeService;
    private readonly ILogger<EmployeesController> _logger;
    private readonly BusinessRulesSettings _businessRules;

    public EmployeesController(
        IEmployeeService employeeService, 
        ILogger<EmployeesController> logger,
        IOptions<BusinessRulesSettings> businessRules)
    {
        _employeeService = employeeService;
        _logger = logger;
        _businessRules = businessRules.Value;
    }

    [HttpPut("{employeeId}")]
    public async Task<IActionResult> UpdateProfile(int employeeId, [FromBody] UpdateEmployeeDto updateDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ApiResponse<object>.ErrorResponse(
                "Validation failed",
                ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList()
            ));
        }

        var response = await _employeeService.UpdateEmployeeProfileAsync(employeeId, updateDto);
        
        if (!response.Success)
            return BadRequest(response);

        return Ok(response);
    }

    [HttpGet("nth-highest-salary/{rank}")]
    public async Task<IActionResult> GetNthHighestSalary(int rank)
    {
        if (rank < _businessRules.MinSalaryRank || rank > _businessRules.MaxSalaryRank)
        {
            return BadRequest(new { 
                success = false, 
                message = $"Rank must be between {_businessRules.MinSalaryRank} and {_businessRules.MaxSalaryRank}" 
            });
        }
        
        var response = await _employeeService.GetNthHighestSalaryEmployeeAsync(rank);
        
        if (!response.Success)
            return NotFound(response);

        return Ok(response);
    }

    [HttpGet("high-earners")]
    public async Task<IActionResult> GetHighEarnersWithPerfectAttendance([FromQuery] decimal minSalary)
    {
        var response = await _employeeService.GetHighEarnersWithPerfectAttendanceAsync(minSalary);
        
        if (!response.Success)
            return BadRequest(response);

        return Ok(response);
    }

    [HttpGet("{employeeId}/hierarchy")]
    public async Task<IActionResult> GetSupervisorHierarchy(int employeeId)
    {
        var response = await _employeeService.GetSupervisorHierarchyAsync(employeeId);
        
        if (!response.Success)
            return NotFound(response);

        return Ok(response);
    }
}
