namespace dotnet_backend_crud_base_model.DTOs.Employee;

public class EmployeeBaseDto
{
    public string? Nik { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Address { get; set; }

    public string? Gender { get; set; }

    public string? PlaceOfBirth { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public int? JobTitleId { get; set; }

    public DateTime? HireDate { get; set; }
}