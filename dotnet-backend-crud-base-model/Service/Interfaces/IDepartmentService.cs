using dotnet_backend_crud_base_model.DTOs.Department;

namespace dotnet_backend_crud_base_model.Services.Interfaces;

public interface IDepartmentService
{
    Task<List<DepartmentResponseDto>> GetAllAsync();
}