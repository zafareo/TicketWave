using Application.Commons.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Reservations.Commands.ReturnTicket;

public class ReturnTicketCustomerCommandHandler : IRequestHandler<ReturnCustomerTicketCommand, bool>
{
    private readonly IApplicationDbContext _context;
    public ReturnTicketCustomerCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<bool> Handle(ReturnCustomerTicketCommand request, CancellationToken cancellationToken)
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
        var res = _context.ScheduledEvents.Include(a => a.Reservations).Where(s => s.Reservations.Any(x => x.Id == request.ReservationId)).FirstOrDefault();
        if ((res.Start - DateTime.Now).TotalHours >= 24)
        {
            reservation.IsCancelled = true;

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        return false;
    }
}