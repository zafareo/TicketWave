using Application.Commons.Models;
using Application.UseCases.Permissions.Commands;
using Application.UseCases.Permissions.Queries;
using Application.UseCases.Permissions;
using Microsoft.AspNetCore.Mvc;

namespace TicketWave.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PermissionController : BaseApiController
{
    [HttpGet("[action]")]
    public async ValueTask<PaginatedList<PermissionResponse>> GetAllPermissions([FromQuery] GetAllPermissionQuery query)
   => await _mediator.Send(query);
    [HttpPost("[action]")]
    public async ValueTask<List<PermissionResponse>> CreatePermission(CreatePermissionCommand command)
   => await _mediator.Send(command);
}
