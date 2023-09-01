using MediatR;

namespace Application.UseCases.Rows.Commands;

public class CreateRowCommand : IRequest<Guid>
{
    public Guid VenueId { get; set; }
    public int Number { get; set; }
    public int SeatsEachRow { get; set; }
}
