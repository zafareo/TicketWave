using Application.Commons.Models;
using Application.UseCases.Events.Commands;
using Application.UseCases.Events.Queries;
using Microsoft.AspNetCore.Mvc;

namespace TicketWave.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventController : BaseApiController
{

    [HttpGet("[action]")]
    public async ValueTask<ActionResult<PaginatedList<GetAllEventsQueryResponse>>> GetAllEvents([FromQuery] GetAllEventsQuery query)
    {
        return await _mediator.Send(query);
    }

    [HttpPost("[action]")]
    public async ValueTask<Guid> CreateEvent(CreateEventCommand command)
    {
        return await _mediator.Send(command);
    }

}
