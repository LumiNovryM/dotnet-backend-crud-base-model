using dotnet_backend_crud_base_model.Models.Entities;

namespace dotnet_backend_crud_base_model.Repositories.Interfaces;

public interface IJobTitleRepository
{
    Task<List<JobTitle>> GetByDepartmentIdAsync(int departmentId);
}