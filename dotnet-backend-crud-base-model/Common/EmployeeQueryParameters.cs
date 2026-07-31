namespace dotnet_backend_crud_base_model.Common;

public class EmployeeQueryParameters
{
    private const int MaxPageSize = 100;

    public int Page { get; set; } = 1;

    private int _pageSize = 10;

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value > MaxPageSize
            ? MaxPageSize
            : value;
    }

    public string? Search { get; set; }

    public string? SortBy { get; set; } = "id";

    public string? SortDirection { get; set; } = "asc";

    public int? DepartmentId { get; set; }

    public int? JobTitleId { get; set; }
}