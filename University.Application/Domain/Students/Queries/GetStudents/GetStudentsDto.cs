using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Application.Domain.Students.Queries.GetStudents
{
    public record GetStudentsDto
    {
        [Required]

        public Guid Id { get; set; }

        [Required]

        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string MiddleName { get; set; }

        public Guid GroupId { get; set; }
    }
}
