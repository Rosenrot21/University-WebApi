using MediatR;

namespace University.Application.Domain.Groups.Commands.RemoveGroupStudent;

public record RemoveGroupStudentCommand(Guid GroupId) : IRequest<Unit>;
