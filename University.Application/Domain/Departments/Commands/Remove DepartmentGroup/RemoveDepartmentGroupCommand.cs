using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace University.Application.Domain.Departments.Commands.Remove_DepartmentGroup;


public record RemoveDepartmentGroupCommand(Guid DepartmentId) : IRequest<Unit>;
