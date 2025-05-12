using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Core.Domain.Students.Models;

namespace University.Persistense.UniversityDb.EntityConfigurations;

public class StudentEntityConfigurations : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.FirstName)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(b => b.LastName)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(b => b.MiddleName)
            .IsRequired()
            .HasMaxLength(20);
    }
}