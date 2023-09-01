using MediatR;

namespace Application.UseCases.ScheduledEvents.Commands;

public class CreateScheduledEventCommand : IRequest<Guid>
{
    public Guid EventId { get; set; }
    public Guid VenueId { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public decimal Price { get; set; }
}
