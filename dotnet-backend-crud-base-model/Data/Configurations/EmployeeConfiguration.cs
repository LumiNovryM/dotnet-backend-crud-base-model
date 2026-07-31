using dotnet_backend_crud_base_model.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_backend_crud_base_model.Data.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employees");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Nik)
            .HasMaxLength(20)
            .IsUnicode(false);

        builder.Property(x => x.FirstName)
            .HasMaxLength(255)
            .IsUnicode(false);

        builder.Property(x => x.LastName)
            .HasMaxLength(255)
            .IsUnicode(false);

        builder.Property(x => x.Address)
            .HasMaxLength(255)
            .IsUnicode(false);

        builder.Property(x => x.Gender)
            .HasMaxLength(1)
            .IsUnicode(false)
            .IsFixedLength();

        builder.Property(x => x.PlaceOfBirth)
            .HasMaxLength(255)
            .IsUnicode(false);

        builder.Property(x => x.Email)
            .HasMaxLength(255)
            .IsUnicode(false);

        builder.Property(x => x.Phone)
            .HasMaxLength(20)
            .IsUnicode(false);

        builder.Property(x => x.DateOfBirth)
            .HasColumnType("datetime");

        builder.Property(x => x.HireDate)
            .HasColumnType("datetime");

        builder.HasOne(x => x.JobTitle)
            .WithMany(x => x.Employees)
            .HasForeignKey(x => x.JobTitleId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}