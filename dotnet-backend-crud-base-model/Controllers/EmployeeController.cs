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

        return Ok(result);
    }
}