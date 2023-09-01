using MediatR;

namespace Application.UseCases.Seats.Commands.CreateSeat;
public class CreateSeatCommand : IRequest<Guid>
{
    public Guid RowId { get; set; }
    public int Number { get; set; }
}
