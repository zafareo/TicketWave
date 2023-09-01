using Application.UseCases.Roles.Commands;
using Application.UseCases.Roles.Queries;
using Microsoft.AspNetCore.Mvc;

namespace TicketWave.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoleController : BaseApiController
{
    [HttpGet("[action]")]
    public async ValueTask<List<RoleResponse>> GetAllRoles()
   => await _mediator.Send(new GetAllRoleQuery());
    [HttpPost("[action]")]
    public async ValueTask<Guid> CreateRole(CreateRoleCommand command)
  => await _mediator.Send(command);
}
