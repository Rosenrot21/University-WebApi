using Microsoft.EntityFrameworkCore;
using University.Core.Domain.Groups.Common;
using University.Core.Domain.Groups.Models;
using University.Persistence.UniversityDb;

namespace University.Infrastructure.Core.Domain.Groups.Common;

public class GroupStudentRepository : IGroupStudentRepository
{
    private readonly UniversityDbContext _universityDbContext;

    public GroupStudentRepository(UniversityDbContext universityDbContext)
    {
        _universityDbContext = universityDbContext;
    }

    public async Task<GroupStudent> FindAsync(Guid groupId)
    {
        var group = await _universityDbContext.GroupStudents.SingleOrDefaultAsync(x => x.GroupId == groupId);

        return group ?? throw new InvalidOperationException();
    }

    public async Task AddAsync(GroupStudent groupStudent)
    {
        await _universityDbContext.GroupStudents.AddAsync(groupStudent);
    }

    public async Task DeleteAsync(Guid groupId)
    {
        var groupBeRemoved = await _universityDbContext.GroupStudents.SingleOrDefaultAsync(x => x.GroupId == groupId);
        if (groupBeRemoved is null) throw new InvalidOperationException();
        _universityDbContext.GroupStudents.Remove(groupBeRemoved);
    }
}
