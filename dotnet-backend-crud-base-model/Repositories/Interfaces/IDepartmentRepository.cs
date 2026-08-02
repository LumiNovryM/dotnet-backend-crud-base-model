using dotnet_backend_crud_base_model.Models.Entities;

namespace dotnet_backend_crud_base_model.Repositories.Interfaces;

public interface IDepartmentRepository
{
    Task<List<Department>> GetAllAsync();
}