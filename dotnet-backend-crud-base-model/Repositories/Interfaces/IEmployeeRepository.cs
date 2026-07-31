using dotnet_backend_crud_base_model.Common;
using dotnet_backend_crud_base_model.Models.Entities;

namespace dotnet_backend_crud_base_model.Repositories.Interfaces;

public interface IEmployeeRepository
{
    Task<PagedResult<Employee>> GetAllAsync(
        int page,
        int pageSize,
        string? search,
        string? sortBy,
        string? sortDirection
    );


    Task<Employee?> GetByIdAsync(long id);


    Task AddAsync(Employee employee);


    void Update(Employee employee);


    void Delete(Employee employee);


    Task<bool> ExistsAsync(long id);
}