using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Core.Domain.Students.Data;

public record CreateStudentData(
    string FirstName,
    string LastName,
    string Passport,
    Guid GroupId);

