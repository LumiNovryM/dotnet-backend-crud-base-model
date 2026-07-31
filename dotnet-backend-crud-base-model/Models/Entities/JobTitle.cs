namespace dotnet_backend_crud_base_model.Models.Entities
{
    public class JobTitle
    {
        public int Id { get; set; }

        public string? JobTitleName { get; set; }

        public int? DepartmentId { get; set; }

        public Department? Department { get; set; }

        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
