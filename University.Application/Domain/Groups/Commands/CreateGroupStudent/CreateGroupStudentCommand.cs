
using MediatR;

namespace University.Application.Domain.Groups.Commands.CreateGroupStudent;


public record CreateGroupStudentCommand(Guid GroupId, Guid StudentId) : IRequest<Guid>;
