using MediatR;
namespace Application.UseCases.Reservations.Commands.ReturnCustomerTicket;

public class ReturnTicketCommand : IRequest<bool>
{
    public Guid ReservationId { get; set; }
}
