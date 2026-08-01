using dotnet_backend_crud_base_model.Common;
using dotnet_backend_crud_base_model.DTOs.Employee;
using dotnet_backend_crud_base_model.Requests.Employee;

namespace dotnet_backend_crud_base_model.Services.Interfaces;

public interface IEmployeeService
{
    Task<PagedResult<EmployeeResponseDto>> GetAllAsync(EmployeeQueryParameters query);

    Task<EmployeeResponseDto?> GetByIdAsync(long id);

    Task<EmployeeResponseDto> CreateAsync(EmployeeCreateDto dto);

    Task<EmployeeResponseDto?> UpdateAsync(long id, EmployeeUpdateDto dto);

    Task<bool> DeleteAsync(long id);
}