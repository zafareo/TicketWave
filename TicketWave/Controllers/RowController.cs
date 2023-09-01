using Application.Commons.Models;
using Application.UseCases.Rows.Commands;
using Application.UseCases.Rows.Queries;
using Microsoft.AspNetCore.Mvc;

namespace TicketWave.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RowController : BaseApiController
{
    [HttpGet("[action]")]
    public async ValueTask<ActionResult<PaginatedList<GetAllRowsQueryResponse>>> GetAllRows([FromQuery] GetAllRowsQuery query)
    {
        return await _mediator.Send(query);
    }

    [HttpPost("[action]")]
    public async ValueTask<Guid> CreateRow(CreateRowCommand command)
    {
        return await _mediator.Send(command);
    }
}
