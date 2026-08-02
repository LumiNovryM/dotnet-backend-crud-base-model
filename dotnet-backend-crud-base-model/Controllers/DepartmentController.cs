using dotnet_backend_crud_base_model.Common;
using dotnet_backend_crud_base_model.DTOs.Department;
using dotnet_backend_crud_base_model.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_backend_crud_base_model.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DepartmentController : ControllerBase
{
    private readonly IDepartmentService _service;


    public DepartmentController(
        IDepartmentService service)
    {
        _service = service;
    }


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var departments = await _service.GetAllAsync();

        return Ok(new ApiResponse<List<DepartmentResponseDto>>
        {
            Success = true,
            Message = "Departments retrieved successfully.",
            Data = departments
        });
    }
}