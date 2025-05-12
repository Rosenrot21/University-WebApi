using MediatR;
using PagesResponses;
using Microsoft.AspNetCore.Mvc;
using University.Api.Common;
using University.Api.Domain.Groups.Request;
using University.Application.Domain.Groups.Commands.CreateGroup;
using University.Application.Domain.Groups.Commands.RemoveGroup;
using University.Application.Domain.Groups.Queries.GetGroup;
using University.Application.Domain.Groups.Commands.RemoveGroupStudent;
using University.Application.Domain.Groups.Commands.CreateGroupStudent;

namespace University.Api.Domain.Groups;

[ApiController]
[Route(Routs.Groups)]
public class GroupsController : ControllerBase
{
    private readonly IMediator _mediator;

    public GroupsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(PageResponse<GroupDto[]>), StatusCodes.Status200OK)]
    public async Task<GroupDto[]> GetGroup(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        var query = new GetGroupQuery(pageNumber, pageSize);
        return await _mediator.Send(query, cancellationToken);
    }

    [HttpPost]
    [ProducesResponseType(typeof(PageResponse<GroupDto[]>), StatusCodes.Status200OK)]
    public async Task<Guid> CreateGroup([FromBody] CreateGroupsRequest request, CancellationToken cancellationToken)
    {
        var command = new CreateGroupCommand(request.Name);
        var id = await _mediator.Send(command, cancellationToken);
        return id;
    }

    [HttpDelete]
    public async Task DeleteGroup([FromBody] RemoveGroupRequest request, CancellationToken cancellationToken)
    {
        var command = new RemoveGroupCommand(request.Id);
        await _mediator.Send(command, cancellationToken);
    }

    [HttpPost("add-students")]
    public async Task CreateStudents([FromBody] CreateGroupStudentRequest request, CancellationToken cancellationToken)
    {
        var command = new CreateGroupStudentCommand(request.GroupId, request.StudentId);
        await _mediator.Send(command, cancellationToken);
    }

    [HttpDelete("delete-students")]
    public async Task DeleteDepartments([FromBody] RemoveGroupStudentRequest request, CancellationToken cancellationToken)
    {
        var command = new RemoveGroupStudentCommand(request.GroupId);
        await _mediator.Send(command, cancellationToken);
    }
}