namespace dotnet_backend_crud_base_model.Models.Entities
{
    public class Department
    {
        public int Id { get; set; }

        public string? DepartmentName { get; set; }

        public string? Abbreviation { get; set; }

        public ICollection<JobTitle> JobTitles { get; set; } = new List<JobTitle>();
    }
}
