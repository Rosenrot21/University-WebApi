using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Core.Domain.Faculties.Models;
using University.Core.Domain.Groups.Models;

namespace University.Core.Domain.Departments.Models
{
    public class DepartmentGroup
    {
        private DepartmentGroup()
        {

        }

        private DepartmentGroup(Guid departmentId, Guid groupId)
        {
            DepartmentId = departmentId;
            GroupId = groupId;
        }

        public Guid DepartmentId { get; set; }
        public Guid GroupId { get; set; }

        public Group Group { get; set; }

        public static DepartmentGroup Create(Guid departmentId, Guid groupId)
        {
            return new DepartmentGroup(departmentId, groupId);
        }
    }
}
