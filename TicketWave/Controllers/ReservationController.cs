using Application.Commons.Models;
using Application.UseCases.Reservations.Commands.CreateReservation;
using Application.UseCases.Reservations.Commands.ReturnCustomerTicket;
using Application.UseCases.Reservations.Commands.ReturnTicket;
using Application.UseCases.Reservations.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TicketWave.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReservationController : BaseApiController
{
    [HttpGet("[action]")]
    public async ValueTask<ActionResult<PaginatedList<GetAllReservationsQueryResponse>>> GetAllReservations([FromQuery] GetAllReservationsQuery query)
    {
        return await _mediator.Send(query);
    }

    [HttpPost("[action]")]
    public async ValueTask<Guid> CreateReservation(CreateReservationCommand command)
    {
        return await _mediator.Send(command);
    }
    [Authorize(Roles = "Admin")]
    [HttpPost("[action]")]
    public async ValueTask<bool> CancelReservation(ReturnTicketCommand command)
    {
        return await _mediator.Send(command);
    }
    [HttpPost("[action]")]
    public async ValueTask<bool> CancelReservationCustomer(ReturnCustomerTicketCommand command)
    {
        return await _mediator.Send(command);
    }
}
