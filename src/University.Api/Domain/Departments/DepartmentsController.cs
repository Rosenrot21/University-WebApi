using MediatR;
using Microsoft.AspNetCore.Mvc;
using PagesResponses;
using University.Api.Common;
using University.Api.Domain.Departments.Request;
using University.Application.Domain.Departments.Commands.CreateDepartment;
using University.Application.Domain.Departments.Commands.CreateDepartmentGroup;
using University.Application.Domain.Departments.Commands.Remove_DepartmentGroup;
using University.Application.Domain.Departments.Commands.RemoveDepartment;
using University.Application.Domain.Departments.Queries.GetDepartment;
using University.Application.Domain.Faculties.Commands.CreateFacultyDepartments;
using University.Application.Domain.Faculties.Commands.RemoveFaculty;
using University.Application.Domain.Faculties.Commands.RemoveFacultyDepartments;

namespace University.Api.Domain.Departments;

[ApiController]
[Route(Routs.Departments)]
public class DepartmentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public DepartmentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(PageResponse<DepartmentDto[]>), StatusCodes.Status200OK)]
    public async Task<DepartmentDto[]> GetDepartment(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        var query = new GetDepartmentQuery(pageNumber, pageSize);
        return await _mediator.Send(query, cancellationToken);
    }

    [HttpPost]
    [ProducesResponseType(typeof(PageResponse<DepartmentDto[]>), StatusCodes.Status200OK)]
    public async Task<Guid> CreateDepartment([FromBody] CreateDepartmentsRequest request, CancellationToken cancellationToken)
    {
        var command = new CreateDepartmentCommand(request.Name);
        var id = await _mediator.Send(command, cancellationToken);
        return id;
    }

    [HttpDelete]
    public async Task DeleteDepartment([FromBody] RemoveDepartmentRequest request, CancellationToken cancellationToken)
    {
        var command = new RemoveDepartmentCommand(request.Id);
        await _mediator.Send(command, cancellationToken);
    }

    [HttpPost("add-group")]
    public async Task CreateGroup([FromBody] CreateDepartmentGroupRequest request, CancellationToken cancellationToken)
    {
        var command = new CreateDepartmentGroupCommand(request.DepartmentId, request.GroupId);
        await _mediator.Send(command, cancellationToken);
    }


    [HttpDelete("delete-group")]
    public async Task DeleteGroups([FromBody] RemoveDepartmentGroupRequest request, CancellationToken cancellationToken)
    {
        var command = new RemoveDepartmentGroupCommand(request.DepartmentId);
        await _mediator.Send(command, cancellationToken);
    }
}