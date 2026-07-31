using dotnet_backend_crud_base_model.Common;
using dotnet_backend_crud_base_model.Data;
using dotnet_backend_crud_base_model.Models.Entities;
using dotnet_backend_crud_base_model.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace dotnet_backend_crud_base_model.Repositories.Implementations;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly ApplicationDbContext _context;

    public EmployeeRepository(ApplicationDbContext context)
    {
        _context = context;
    }


    public async Task<PagedResult<Employee>> GetAllAsync(
        int page,
        int pageSize,
        string? search,
        string? sortBy,
        string? sortDirection)
    {
        var query = _context.Employees
            .Include(x => x.JobTitle)
            .ThenInclude(x => x!.Department)
            .AsQueryable();


        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(x =>
                x.Nik!.Contains(search) ||
                x.FirstName!.Contains(search) ||
                x.LastName!.Contains(search) ||
                x.Email!.Contains(search) ||
                x.JobTitle!.JobTitleName!.Contains(search) ||
                x.JobTitle.Department!.DepartmentName!.Contains(search)
            );
        }


        var totalRecords = await query.CountAsync();


        query = sortBy?.ToLower() switch
        {
            "firstname" => sortDirection == "desc"
                ? query.OrderByDescending(x => x.FirstName)
                : query.OrderBy(x => x.FirstName),


            "lastname" => sortDirection == "desc"
                ? query.OrderByDescending(x => x.LastName)
                : query.OrderBy(x => x.LastName),


            "email" => sortDirection == "desc"
                ? query.OrderByDescending(x => x.Email)
                : query.OrderBy(x => x.Email),


            "department" => sortDirection == "desc"
                ? query.OrderByDescending(
                    x => x.JobTitle!.Department!.DepartmentName)
                : query.OrderBy(
                    x => x.JobTitle!.Department!.DepartmentName),


            "jobtitle" => sortDirection == "desc"
                ? query.OrderByDescending(
                    x => x.JobTitle!.JobTitleName)
                : query.OrderBy(
                    x => x.JobTitle!.JobTitleName),


            "hiredate" => sortDirection == "desc"
                ? query.OrderByDescending(x => x.HireDate)
                : query.OrderBy(x => x.HireDate),


            _ => query.OrderBy(x => x.Id)
        };


        var data = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();


        return new PagedResult<Employee>
        {
            Data = data,
            Page = page,
            PageSize = pageSize,
            TotalRecords = totalRecords
        };
    }



    public async Task<Employee?> GetByIdAsync(long id)
    {
        return await _context.Employees
            .Include(x => x.JobTitle)
            .ThenInclude(x => x!.Department)
            .FirstOrDefaultAsync(x => x.Id == id);
    }



    public async Task AddAsync(Employee employee)
    {
        await _context.Employees.AddAsync(employee);

        await _context.SaveChangesAsync();
    }



    public void Update(Employee employee)
    {
        _context.Employees.Update(employee);
    }



    public void Delete(Employee employee)
    {
        _context.Employees.Remove(employee);
    }



    public async Task<bool> ExistsAsync(long id)
    {
        return await _context.Employees
            .AnyAsync(x => x.Id == id);
    }
}