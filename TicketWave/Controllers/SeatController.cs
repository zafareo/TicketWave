using Application.Commons.Models;
using Application.UseCases.Seats.Commands.CreateSeat;
using Application.UseCases.Seats.Queries.AllSeats;
using Application.UseCases.Seats.Queries.EmptySeats;
using Microsoft.AspNetCore.Mvc;
using TicketWave.Services;

namespace TicketWave.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SeatController : BaseApiController
{
    [LazyCache(5, 10)]
    [HttpGet("[action]")]
    public async ValueTask<ActionResult<PaginatedList<GetAllSeatsQueryResponse>>> GetAllSeats([FromQuery] GetAllSeatsQuery query)
    {
        return await _mediator.Send(query);
    }
    [HttpGet("[action]")]
    public async ValueTask<ActionResult<List<GetAllEmptySeatsQueryResponse>>> GetAllEmptySeats([FromQuery] GetAllEmptySeatsQuery query)
    {
        return await _mediator.Send(query);
    }
    [HttpPost("[action]")]
    public async ValueTask<Guid> CreateSeat(CreateSeatCommand command)
    {
        return await _mediator.Send(command);
    }
}
