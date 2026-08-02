using dotnet_backend_crud_base_model.Data;
using dotnet_backend_crud_base_model.Models.Entities;
using dotnet_backend_crud_base_model.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace dotnet_backend_crud_base_model.Repositories.Implementations;

public class JobTitleRepository : IJobTitleRepository
{
    private readonly ApplicationDbContext _context;


    public JobTitleRepository(ApplicationDbContext context)
    {
        _context = context;
    }


    public async Task<List<JobTitle>> GetByDepartmentIdAsync(int departmentId)
    {
        return await _context.JobTitles
            .Where(x => x.DepartmentId == departmentId)
            .OrderBy(x => x.JobTitleName)
            .ToListAsync();
    }
}