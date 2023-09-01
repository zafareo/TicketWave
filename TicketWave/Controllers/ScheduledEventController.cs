using Application.Commons.Models;
using Application.UseCases.ScheduledEvents.Commands;
using Application.UseCases.ScheduledEvents.Queries;
using Microsoft.AspNetCore.Mvc;

namespace TicketWave.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ScheduledEventController : BaseApiController
{
    [HttpGet("[action]")]
    public async ValueTask<ActionResult<PaginatedList<GetAllScheduledEventQueryResponse>>> GetAllScheduledEvents([FromQuery] GetAllScheduledEventQuery query)
    {
        return await _mediator.Send(query);
    }

    [HttpPost("[action]")]
    public async ValueTask<Guid> CreateScheduledEvent(CreateScheduledEventCommand command)
    {
        return await _mediator.Send(command);
    }
}
