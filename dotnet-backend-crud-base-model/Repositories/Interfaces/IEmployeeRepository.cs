using dotnet_backend_crud_base_model.Common;
using dotnet_backend_crud_base_model.Requests.Employee;
using dotnet_backend_crud_base_model.Models.Entities;

namespace dotnet_backend_crud_base_model.Repositories.Interfaces;

public interface IEmployeeRepository
{
    Task<PagedResult<Employee>> GetAllAsync(
    EmployeeQueryParameters parameters);


    Task<Employee?> GetByIdAsync(long id);


    Task AddAsync(Employee employee);

    Task UpdateAsync(Employee employee);

    Task DeleteAsync(Employee employee);


    Task<bool> ExistsAsync(long id);
}