using MediatR;
using University.Core.Common;
using University.Core.Domain.Departments.Common;
using University.Core.Domain.Departments.Models;

namespace University.Application.Domain.Departments.Commands.CreateDepartmentGroup;

public class CreateDepartmentGroupCommandHandler : IRequestHandler<CreateDepartmentGroupCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    private readonly IDepartmentGroupRepository _departmentGroupRepository;

    public CreateDepartmentGroupCommandHandler(IUnitOfWork unitOfWork, IDepartmentGroupRepository departmentGroupRepository)
    {
        _unitOfWork = unitOfWork;
        _departmentGroupRepository = departmentGroupRepository;
    }

    public async Task<Guid> Handle(CreateDepartmentGroupCommand command, CancellationToken cancellationToken)
    {
        var departmentGroups = DepartmentGroup.Create(command.DepartmentId, command.GroupId);
        await _departmentGroupRepository.AddAsync(departmentGroups);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return departmentGroups.DepartmentId;
    }
}