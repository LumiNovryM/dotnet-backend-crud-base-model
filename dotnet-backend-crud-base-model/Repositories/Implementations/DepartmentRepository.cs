using dotnet_backend_crud_base_model.Data;
using dotnet_backend_crud_base_model.Models.Entities;
using dotnet_backend_crud_base_model.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace dotnet_backend_crud_base_model.Repositories.Implementations;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly ApplicationDbContext _context;

    public DepartmentRepository(ApplicationDbContext context)
    {
        _context = context;
    }


    public async Task<List<Department>> GetAllAsync()
    {
        return await _context.Departments
            .OrderBy(x => x.DepartmentName)
            .ToListAsync();
    }
}