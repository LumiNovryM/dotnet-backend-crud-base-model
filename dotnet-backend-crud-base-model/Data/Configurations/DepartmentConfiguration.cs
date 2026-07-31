using dotnet_backend_crud_base_model.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_backend_crud_base_model.Data.Configurations;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable("Departments");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.DepartmentName)
            .HasMaxLength(255)
            .IsUnicode(false);

        builder.Property(x => x.Abbreviation)
            .HasMaxLength(10)
            .IsUnicode(false);
    }
}