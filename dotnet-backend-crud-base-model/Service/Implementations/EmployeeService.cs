using AutoMapper;
using dotnet_backend_crud_base_model.Common;
using dotnet_backend_crud_base_model.DTOs.Employee;
using dotnet_backend_crud_base_model.Models.Entities;
using dotnet_backend_crud_base_model.Repositories.Interfaces;
using dotnet_backend_crud_base_model.Requests.Employee;
using dotnet_backend_crud_base_model.Services.Interfaces;

namespace dotnet_backend_crud_base_model.Services.Implementations;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _repository;
    private readonly IMapper _mapper;


    public EmployeeService(
    IEmployeeRepository repository,
    IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }



    public async Task<PagedResult<EmployeeResponseDto>> GetAllAsync(EmployeeQueryParameters query)
    {
        var result = await _repository.GetAllAsync(query);

        return new PagedResult<EmployeeResponseDto>
        {
            Data = _mapper.Map<List<EmployeeResponseDto>>(result.Data),
            Page = result.Page,
            PageSize = result.PageSize,
            TotalRecords = result.TotalRecords
        };
    }



    public async Task<EmployeeResponseDto?> GetByIdAsync(long id)
    {
        var employee = await _repository.GetByIdAsync(id);

        if (employee is null)
            return null;

        return _mapper.Map<EmployeeResponseDto>(employee);
    }



    public async Task<EmployeeResponseDto> CreateAsync(EmployeeCreateDto dto)
    {
        var employee = _mapper.Map<Employee>(dto);

        await _repository.AddAsync(employee);

        employee = await _repository.GetByIdAsync(employee.Id);

        return _mapper.Map<EmployeeResponseDto>(employee!);
    }



    public async Task<EmployeeResponseDto?> UpdateAsync(
    long id,
    EmployeeUpdateDto dto)
    {
        var employee = await _repository.GetByIdAsync(id);

        if (employee == null)
            return null;

        _mapper.Map(dto, employee);

        await _repository.UpdateAsync(employee);

        employee = await _repository.GetByIdAsync(id);

        return _mapper.Map<EmployeeResponseDto>(employee);
    }



    public async Task<bool> DeleteAsync(long id)
    {
        var employee = await _repository.GetByIdAsync(id);

        if (employee == null)
            return false;

        await _repository.DeleteAsync(employee);

        return true;
    }
}