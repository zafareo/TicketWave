using MediatR;

namespace Application.UseCases.Venues.Commands;

public class CreateVenueCommand : IRequest<Guid>
{
    public string Name { get; set; }
    public string Address { get; set; }
    public int Capacity { get; set; }

}
