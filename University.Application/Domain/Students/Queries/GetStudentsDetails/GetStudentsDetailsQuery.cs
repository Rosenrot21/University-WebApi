using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using University.Application.Common;
using University.Application.Domain.Students.Queries.GetStudents;

namespace University.Application.Domain.Students.Queries.GetStudentsDetails;

public record GetStudentsDetailsQuery(Guid id) : IRequest<PageResponse<GetStudentsDto[]>>;