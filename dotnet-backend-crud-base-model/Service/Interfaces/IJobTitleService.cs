using dotnet_backend_crud_base_model.DTOs.JobTitle;

namespace dotnet_backend_crud_base_model.Services.Interfaces;

public interface IJobTitleService
{
    Task<List<JobTitleResponseDto>> GetByDepartmentIdAsync(int departmentId);
}