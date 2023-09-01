using Application.Commons.Interfaces;
using MediatR;

namespace Application.UseCases.Reservations.Commands.ReturnCustomerTicket;

public class ReturnTicketCommandHandler : IRequestHandler<ReturnTicketCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public ReturnTicketCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<bool> Handle(ReturnTicketCommand request, CancellationToken cancellationToken)
    {
        var reservation = await _context.Reservations.FindAsync(request.ReservationId);

        if (reservation == null)
        {
            return false;
        }

        if (reservation.IsCancelled)
        {
            return false;
        }

        reservation.IsCancelled = true;

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
