using System;
using System.Collections.Generic;

using MediatR;

using University.Core.Common;

using University.Core.Domain.Groups.Models;
using University.Core.Domain.Groups.Common;

namespace University.Application.Domain.Groups.Commands.CreateGroupStudent;

public class CreateGroupStudentCommandHandler : IRequestHandler<CreateGroupStudentCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    private readonly IGroupStudentRepository _groupStudentRepository;

    public CreateGroupStudentCommandHandler(IUnitOfWork unitOfWork, IGroupStudentRepository groupStudentRepository)
    {
        _unitOfWork = unitOfWork;
        _groupStudentRepository = groupStudentRepository;
    }

    public async Task<Guid> Handle(CreateGroupStudentCommand command, CancellationToken cancellationToken)
    {
        var groupStudents = GroupStudent.Create(command.GroupId, command.StudentId);
        await _groupStudentRepository.AddAsync(groupStudents);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return groupStudents.GroupId;
    }
}
