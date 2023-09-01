using MediatR;

namespace Application.UseCases.Seats.Queries.EmptySeats;

public class GetAllEmptySeatsQuery : IRequest<List<GetAllEmptySeatsQueryResponse>>
{
    public Guid ScheduledEventId { get; set; }
}
