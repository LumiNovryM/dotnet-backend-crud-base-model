using dotnet_backend_crud_base_model.Common;
using dotnet_backend_crud_base_model.Models.Entities;
using dotnet_backend_crud_base_model.Repositories.Interfaces;
using dotnet_backend_crud_base_model.Services.Interfaces;

namespace dotnet_backend_crud_base_model.Services.Implementations;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;


    public EmployeeService(
        IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }



    public async Task<PagedResult<Employee>> GetAllAsync(
     EmployeeQueryParameters parameters)
    {
        return await _employeeRepository.GetAllAsync(parameters);
    }



    public async Task<Employee?> GetByIdAsync(long id)
    {
        return await _employeeRepository.GetByIdAsync(id);
    }



    public async Task CreateAsync(Employee employee)
    {
        await _employeeRepository.AddAsync(employee);
    }



    public async Task UpdateAsync(Employee employee)
    {
        await _employeeRepository.UpdateAsync(employee);
    }



    public async Task DeleteAsync(long id)
    {
        var employee = await _employeeRepository.GetByIdAsync(id);

        if (employee == null)
        {
            throw new KeyNotFoundException(
                "Employee not found"
            );
        }


        await _employeeRepository.DeleteAsync(employee);
    }
}