namespace Application.UseCases.ScheduledEvents.Queries;
public class GetAllScheduledEventQueryResponse
{
    public Guid Id { get; set; }
    public Guid EventId { get; set; }
    public Guid VenueId { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public decimal Price { get; set; }
}
