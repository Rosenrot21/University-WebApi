namespace University.Api.Domain.Groups.Request;

public record CreateGroupStudentRequest(Guid GroupId, Guid StudentId);
