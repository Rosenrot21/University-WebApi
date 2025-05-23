﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using  University.Core.Domain.Students.Models;

namespace University.Core.Domain.Students.Common;

public interface IStudentsRepository
{

    Task<Student> FindAsync(Guid id);

    Task AddAsync(Student student);

    Task DeleteAsync(Guid id);
}
