using AutoMapper;
using dotnet_backend_crud_base_model.DTOs.Department;
using dotnet_backend_crud_base_model.Repositories.Interfaces;
using dotnet_backend_crud_base_model.Services.Interfaces;

namespace dotnet_backend_crud_base_model.Services.Implementations;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _repository;
    private readonly IMapper _mapper;


    public DepartmentService(
        IDepartmentRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }


    public async Task<List<DepartmentResponseDto>> GetAllAsync()
    {
        var departments = await _repository.GetAllAsync();

        return _mapper.Map<List<DepartmentResponseDto>>(departments);
    }
}