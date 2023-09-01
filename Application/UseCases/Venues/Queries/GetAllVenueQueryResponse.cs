namespace Application.UseCases.Venues.Queries;

public class GetAllVenueQueryResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public int Capacity { get; set; }
}
