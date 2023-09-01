﻿using Application.Commons.Models;
using Application.UseCases.Venues.Commands;
using Application.UseCases.Venues.Queries;
using Microsoft.AspNetCore.Mvc;

namespace TicketWave.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VenueController : BaseApiController
{
    [HttpGet("[action]")]
    public async ValueTask<ActionResult<PaginatedList<GetAllVenueQueryResponse>>> GetAllVenue([FromQuery] GetAllVenuesQuery query)
    {
        return await _mediator.Send(query);
    }
    [HttpPost("[action]")]
    public async ValueTask<Guid> CreateVenue(CreateVenueCommand command)
    {
        return await _mediator.Send(command);
    }
}
