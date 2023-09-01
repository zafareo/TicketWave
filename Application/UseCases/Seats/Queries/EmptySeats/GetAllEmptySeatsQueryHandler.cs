using Application.Commons.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.Seats.Queries.EmptySeats;

public class GetAllEmptySeatsQueryHandler : IRequestHandler<GetAllEmptySeatsQuery, List<GetAllEmptySeatsQueryResponse>>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;

    public GetAllEmptySeatsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<List<GetAllEmptySeatsQueryResponse>> Handle(GetAllEmptySeatsQuery request, CancellationToken cancellationToken)
    {
        var emptySeatsForEvent = await _context.Seats
       .Where(seat => seat.Reservations.All(reservation => reservation.ScheduledEventId == request.ScheduledEventId && reservation.IsCancelled == true || reservation.ScheduledEventId != request.ScheduledEventId))
       .Select(seat => new GetAllEmptySeatsQueryResponse
       {
           Id = seat.Id,
           Number = seat.Number,
           RowId = seat.RowId

       })
       .ToListAsync(cancellationToken);
        return emptySeatsForEvent;

    }
}

