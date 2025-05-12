
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using University.Core.Domain.Departments.Models;

namespace University.Persistence.UniversityDb.EntityConfigurations;

public class DepartmentGroupEntityConfiguration : IEntityTypeConfiguration<DepartmentGroup>
{
    public void Configure(EntityTypeBuilder<DepartmentGroup> builder)
    {
        builder.HasKey(x => new { x.DepartmentId, x.GroupId });
    }
}
