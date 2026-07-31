using dotnet_backend_crud_base_model.Common;
using dotnet_backend_crud_base_model.Requests.Employee;
using dotnet_backend_crud_base_model.Models.Entities;

namespace dotnet_backend_crud_base_model.Services.Interfaces;

public interface IEmployeeService
{
    Task<PagedResult<Employee>> GetAllAsync(
    EmployeeQueryParameters parameters);

    Task<Employee?> GetByIdAsync(long id);

    Task CreateAsync(Employee employee);

    Task UpdateAsync(Employee employee);

    Task DeleteAsync(long id);
}