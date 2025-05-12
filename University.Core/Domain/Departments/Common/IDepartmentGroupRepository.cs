
using University.Core.Domain.Departments.Models;

namespace University.Core.Domain.Departments.Common;

public interface IDepartmentGroupRepository
{

    Task<DepartmentGroup> FindAsync(Guid DepartmentId);

    Task AddAsync(DepartmentGroup departmentGroup);

    Task DeleteAsync(Guid groupId);

}
