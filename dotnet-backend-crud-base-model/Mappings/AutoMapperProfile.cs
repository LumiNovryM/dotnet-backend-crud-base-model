using AutoMapper;
using dotnet_backend_crud_base_model.DTOs.Employee;
using dotnet_backend_crud_base_model.Models.Entities;

namespace dotnet_backend_crud_base_model.Mappings;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<EmployeeCreateDto, Employee>();

        CreateMap<EmployeeUpdateDto, Employee>();

        CreateMap<Employee, EmployeeResponseDto>()
            .ForMember(
                dest => dest.Department,
                opt => opt.MapFrom(src =>
                    src.JobTitle != null && src.JobTitle.Department != null
                        ? src.JobTitle.Department.DepartmentName
                        : null))
            .ForMember(
                dest => dest.JobTitle,
                opt => opt.MapFrom(src =>
                    src.JobTitle != null
                        ? src.JobTitle.JobTitleName
                        : null));
    }
}