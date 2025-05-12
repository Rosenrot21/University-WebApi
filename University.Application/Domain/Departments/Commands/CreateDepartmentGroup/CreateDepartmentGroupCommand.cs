using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace University.Application.Domain.Departments.Commands.CreateDepartmentGroup;
public record CreateDepartmentGroupCommand(Guid DepartmentId, Guid GroupId) : IRequest<Guid>;
