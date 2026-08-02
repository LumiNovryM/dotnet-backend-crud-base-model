using AutoMapper;
using dotnet_backend_crud_base_model.DTOs.JobTitle;
using dotnet_backend_crud_base_model.Repositories.Interfaces;
using dotnet_backend_crud_base_model.Services.Interfaces;

namespace dotnet_backend_crud_base_model.Services.Implementations;

public class JobTitleService : IJobTitleService
{
    private readonly IJobTitleRepository _repository;
    private readonly IMapper _mapper;


    public JobTitleService(
        IJobTitleRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }


    public async Task<List<JobTitleResponseDto>> GetByDepartmentIdAsync(
        int departmentId)
    {
        var jobTitles =
            await _repository.GetByDepartmentIdAsync(departmentId);

        return _mapper.Map<List<JobTitleResponseDto>>(jobTitles);
    }
}