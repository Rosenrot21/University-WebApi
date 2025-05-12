using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Core.Domain.Groups.Models
{
    public class GroupStudent
    {
        private GroupStudent()
        {

        }

        private GroupStudent(Guid groupId, Guid studentId)
        {
            GroupId = groupId;
            StudentId = studentId;
        }
        public Guid GroupId { get; set; }

        public Guid StudentId { get; set; }

        public Group Student { get; set; }

        public static GroupStudent Create(Guid groupId, Guid studentId)
        {
            return new GroupStudent(groupId, studentId);
        }
    }
}
