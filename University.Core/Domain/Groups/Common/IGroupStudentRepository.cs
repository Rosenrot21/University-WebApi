
using University.Core.Domain.Groups.Models;

namespace University.Core.Domain.Groups.Common
{
    public interface IGroupStudentRepository
    {
        Task<GroupStudent> FindAsync(Guid groupId);

        Task AddAsync(GroupStudent groupStudent);

        Task DeleteAsync(Guid groupId);
    }
}
