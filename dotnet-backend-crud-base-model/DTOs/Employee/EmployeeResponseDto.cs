namespace dotnet_backend_crud_base_model.DTOs.Employee;

public class EmployeeResponseDto
{
    public long Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Department { get; set; }

    public string? JobTitle { get; set; }

    public DateTime? HireDate { get; set; }
}