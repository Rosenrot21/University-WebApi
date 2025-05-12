using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using University.Application.Domain.Faculties.Commands.RemoveFacultyDepartments;
using University.Core.Common;
using University.Core.Domain.Faculties.Common;
using University.Core.Domain.Groups.Common;

namespace University.Application.Domain.Groups.Commands.RemoveGroupStudent;

public class RemoveGroupStudentCommandHandler : IRequestHandler<RemoveGroupStudentCommand, Unit>
{
    private readonly IGroupStudentRepository _groupStudentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveGroupStudentCommandHandler(IGroupStudentRepository groupStudentRepository, IUnitOfWork unitOfWork)
    {
        _groupStudentRepository = groupStudentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(RemoveGroupStudentCommand command, CancellationToken cancellationToken)
    {
        await _groupStudentRepository.DeleteAsync(command.GroupId);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
