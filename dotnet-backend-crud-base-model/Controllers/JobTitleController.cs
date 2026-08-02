using dotnet_backend_crud_base_model.Common;
using dotnet_backend_crud_base_model.DTOs.JobTitle;
using dotnet_backend_crud_base_model.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_backend_crud_base_model.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobTitleController : ControllerBase
{
    private readonly IJobTitleService _service;


    public JobTitleController(
        IJobTitleService service)
    {
        _service = service;
    }


    [HttpGet]
    public async Task<IActionResult> GetByDepartment(
        [FromQuery] int departmentId)
    {
        var jobTitles =
            await _service.GetByDepartmentIdAsync(departmentId);


        return Ok(new ApiResponse<List<JobTitleResponseDto>>
        {
            Success = true,
            Message = "Job titles retrieved successfully.",
            Data = jobTitles
        });
    }
}