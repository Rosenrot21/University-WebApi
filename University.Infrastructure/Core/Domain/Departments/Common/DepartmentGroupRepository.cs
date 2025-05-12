using University.Core.Domain.Departments.Models;
using University.Core.Domain.Departments.Common;
using University.Persistence.UniversityDb;
using Microsoft.EntityFrameworkCore;
namespace University.Infrastructure.Core.Domain.Departments.Common;

public class DepartmentGroupRepository : IDepartmentGroupRepository
{
    private readonly UniversityDbContext _universityDbContext;

    public DepartmentGroupRepository(UniversityDbContext universityDbContext)
    {
        _universityDbContext = universityDbContext;
    }

    public async Task<DepartmentGroup> FindAsync(Guid departmentId)
    {
        var department = await _universityDbContext.DepartmentGroups.SingleOrDefaultAsync(x => x.DepartmentId == departmentId);

        return department ?? throw new InvalidOperationException();
    }

    public async Task AddAsync(DepartmentGroup departmentGroup)
    {
        await _universityDbContext.DepartmentGroups.AddAsync(departmentGroup);
    }

    public async Task DeleteAsync(Guid departmentId)
    {
        var departmentBeRemoved = await _universityDbContext.DepartmentGroups.SingleOrDefaultAsync(x => x.DepartmentId == departmentId);
        if (departmentBeRemoved is null) throw new InvalidOperationException();
        _universityDbContext.DepartmentGroups.Remove(departmentBeRemoved);
    }
}
