using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using University.Application.Domain.Faculties.Commands.RemoveFacultyDepartments;
using University.Core.Common;
using University.Core.Domain.Departments.Common;


namespace University.Application.Domain.Departments.Commands.Remove_DepartmentGroup;

public class RemoveDepartmentGroupCommandHandler : IRequestHandler<RemoveDepartmentGroupCommand, Unit>
{
    private readonly IDepartmentGroupRepository _departmentGroupRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveDepartmentGroupCommandHandler(IDepartmentGroupRepository departmentGroupRepository, IUnitOfWork unitOfWork)
    {
        _departmentGroupRepository = departmentGroupRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(RemoveDepartmentGroupCommand command, CancellationToken cancellationToken)
    {
        await _departmentGroupRepository.DeleteAsync(command.DepartmentId);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
