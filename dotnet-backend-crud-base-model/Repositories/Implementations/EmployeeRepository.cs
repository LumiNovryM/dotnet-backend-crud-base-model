using dotnet_backend_crud_base_model.Common;
using dotnet_backend_crud_base_model.Requests.Employee;
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
    EmployeeQueryParameters parameters)
    {
        var query = _context.Employees
            .Include(x => x.JobTitle)
            .ThenInclude(x => x!.Department)
            .AsQueryable();


        if (!string.IsNullOrWhiteSpace(parameters.Search))
        {
            query = query.Where(x =>
                x.Nik!.Contains(parameters.Search) ||
                x.FirstName!.Contains(parameters.Search) ||
                x.LastName!.Contains(parameters.Search) ||
                x.Email!.Contains(parameters.Search) ||
                x.JobTitle!.JobTitleName!.Contains(parameters.Search) ||
                x.JobTitle.Department!.DepartmentName!.Contains(parameters.Search)
            );
        }


        var totalRecords = await query.CountAsync();


        query = parameters.SortBy?.ToLower() switch
        {
            "firstname" => parameters.SortDirection == "desc"
                ? query.OrderByDescending(x => x.FirstName)
                : query.OrderBy(x => x.FirstName),


            "lastname" => parameters.SortDirection == "desc"
                ? query.OrderByDescending(x => x.LastName)
                : query.OrderBy(x => x.LastName),


            "email" => parameters.SortDirection == "desc"
                ? query.OrderByDescending(x => x.Email)
                : query.OrderBy(x => x.Email),


            "department" => parameters.SortDirection == "desc"
                ? query.OrderByDescending(
                    x => x.JobTitle!.Department!.DepartmentName)
                : query.OrderBy(
                    x => x.JobTitle!.Department!.DepartmentName),


            "jobtitle" => parameters.SortDirection == "desc"
                ? query.OrderByDescending(
                    x => x.JobTitle!.JobTitleName)
                : query.OrderBy(
                    x => x.JobTitle!.JobTitleName),


            "hiredate" => parameters.SortDirection == "desc"
                ? query.OrderByDescending(x => x.HireDate)
                : query.OrderBy(x => x.HireDate),


            _ => query.OrderBy(x => x.Id)
        };

        if (parameters.DepartmentId.HasValue)
        {
            query = query.Where(x =>
                x.JobTitle!.DepartmentId == parameters.DepartmentId);
        }

        if (parameters.JobTitleId.HasValue)
        {
            query = query.Where(x =>
                x.JobTitleId == parameters.JobTitleId);
        }

        var data = await query
            .Skip((parameters.Page - 1) * parameters.PageSize)
            .Take(parameters.PageSize)
            .ToListAsync();


        return new PagedResult<Employee>
        {
            Data = data,
            Page = parameters.Page,
            PageSize = parameters.PageSize,
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



    public async Task UpdateAsync(Employee employee)
    {
        _context.Employees.Update(employee);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Employee employee)
    {
        _context.Employees.Remove(employee);

        await _context.SaveChangesAsync();
    }



    public async Task<bool> ExistsAsync(long id)
    {
        return await _context.Employees
            .AnyAsync(x => x.Id == id);
    }
}