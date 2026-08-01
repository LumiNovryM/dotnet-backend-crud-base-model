using dotnet_backend_crud_base_model.Common;
using dotnet_backend_crud_base_model.DTOs.Employee;
using dotnet_backend_crud_base_model.Requests.Employee;
using dotnet_backend_crud_base_model.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_backend_crud_base_model.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(
    [FromQuery] EmployeeQueryParameters query)
    {
        var result = await _employeeService.GetAllAsync(query);

        return Ok(new ApiResponse<PagedResult<EmployeeResponseDto>>
        {
            Success = true,
            Message = "Employees retrieved successfully.",
            Data = result
        });
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetById(long id)
    {
        var employee = await _employeeService.GetByIdAsync(id);

        if (employee is null)
        {
            return NotFound(new ApiResponse<object>
            {
                Success = false,
                Message = "Employee not found.",
                Data = null
            });
        }

        return Ok(new ApiResponse<EmployeeResponseDto>
        {
            Success = true,
            Message = "Employee retrieved successfully.",
            Data = employee
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create(
    [FromBody] EmployeeCreateDto dto)
    {
        var employee = await _employeeService.CreateAsync(dto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = employee.Id },
            new ApiResponse<EmployeeResponseDto>
            {
                Success = true,
                Message = "Employee created successfully.",
                Data = employee
            });
    }
}