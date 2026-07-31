using dotnet_backend_crud_base_model.Data;
using dotnet_backend_crud_base_model.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace dotnet_backend_crud_base_model.Data.Seed;

public static class DbSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        await context.Database.MigrateAsync();


        // Seed Departments
        if (!await context.Departments.AnyAsync())
        {
            var departments = new List<Department>
            {
                new()
                {
                    DepartmentName = "Information Technology",
                    Abbreviation = "IT"
                },
                new()
                {
                    DepartmentName = "Human Resource",
                    Abbreviation = "HR"
                },
                new()
                {
                    DepartmentName = "Finance",
                    Abbreviation = "FIN"
                },
                new()
                {
                    DepartmentName = "Marketing",
                    Abbreviation = "MKT"
                },
                new()
                {
                    DepartmentName = "Operations",
                    Abbreviation = "OPS"
                }
            };


            await context.Departments.AddRangeAsync(departments);
            await context.SaveChangesAsync();
        }



        // Seed Job Titles
        if (!await context.JobTitles.AnyAsync())
        {
            var departments = await context.Departments.ToListAsync();

            var jobTitles = new List<JobTitle>
            {
                new()
                {
                    JobTitleName = "Backend Developer",
                    DepartmentId = departments
                        .First(x => x.Abbreviation == "IT")
                        .Id
                },

                new()
                {
                    JobTitleName = "Frontend Developer",
                    DepartmentId = departments
                        .First(x => x.Abbreviation == "IT")
                        .Id
                },

                new()
                {
                    JobTitleName = "HR Specialist",
                    DepartmentId = departments
                        .First(x => x.Abbreviation == "HR")
                        .Id
                },

                new()
                {
                    JobTitleName = "Financial Analyst",
                    DepartmentId = departments
                        .First(x => x.Abbreviation == "FIN")
                        .Id
                },

                new()
                {
                    JobTitleName = "Marketing Executive",
                    DepartmentId = departments
                        .First(x => x.Abbreviation == "MKT")
                        .Id
                }
            };


            await context.JobTitles.AddRangeAsync(jobTitles);
            await context.SaveChangesAsync();
        }



        // Seed Employees
        if (!await context.Employees.AnyAsync())
        {
            var jobTitles = await context.JobTitles.ToListAsync();

            var employees = new List<Employee>
            {
                new()
                {
                    Nik = "EMP001",
                    FirstName = "Lumi",
                    LastName = "Novry",
                    Address = "Jakarta",
                    Gender = "M",
                    PlaceOfBirth = "Depok",
                    DateOfBirth = new DateTime(2005,11,7),
                    Email = "lumi@example.com",
                    Phone = "081234567890",
                    JobTitleId = jobTitles
                        .First(x => x.JobTitleName == "Backend Developer")
                        .Id,
                    HireDate = DateTime.Now.AddYears(-2)
                },

                new()
                {
                    Nik = "EMP002",
                    FirstName = "John",
                    LastName = "Doe",
                    Address = "Bandung",
                    Gender = "M",
                    PlaceOfBirth = "Bandung",
                    DateOfBirth = new DateTime(1998,5,10),
                    Email = "john@example.com",
                    Phone = "081234567891",
                    JobTitleId = jobTitles
                        .First(x => x.JobTitleName == "Frontend Developer")
                        .Id,
                    HireDate = DateTime.Now.AddYears(-1)
                },

                new()
                {
                    Nik = "EMP003",
                    FirstName = "Sarah",
                    LastName = "Williams",
                    Address = "Jakarta",
                    Gender = "F",
                    PlaceOfBirth = "Jakarta",
                    DateOfBirth = new DateTime(1997,8,20),
                    Email = "sarah@example.com",
                    Phone = "081234567892",
                    JobTitleId = jobTitles
                        .First(x => x.JobTitleName == "HR Specialist")
                        .Id,
                    HireDate = DateTime.Now.AddYears(-3)
                },

                new()
                {
                    Nik = "EMP004",
                    FirstName = "Michael",
                    LastName = "Smith",
                    Address = "Surabaya",
                    Gender = "M",
                    PlaceOfBirth = "Surabaya",
                    DateOfBirth = new DateTime(1995,2,15),
                    Email = "michael@example.com",
                    Phone = "081234567893",
                    JobTitleId = jobTitles
                        .First(x => x.JobTitleName == "Financial Analyst")
                        .Id,
                    HireDate = DateTime.Now.AddYears(-4)
                },

                new()
                {
                    Nik = "EMP005",
                    FirstName = "Anna",
                    LastName = "Taylor",
                    Address = "Bali",
                    Gender = "F",
                    PlaceOfBirth = "Bali",
                    DateOfBirth = new DateTime(2000,12,1),
                    Email = "anna@example.com",
                    Phone = "081234567894",
                    JobTitleId = jobTitles
                        .First(x => x.JobTitleName == "Marketing Executive")
                        .Id,
                    HireDate = DateTime.Now.AddMonths(-8)
                }
            };


            await context.Employees.AddRangeAsync(employees);
            await context.SaveChangesAsync();
        }
    }
}