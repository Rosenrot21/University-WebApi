using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;


namespace University.Application.Domain.Students.Queries.GetStudents;

public record GetStudentsQuery( int PageSize, int PageNumber) : IRequest<StudentDto[]>;

