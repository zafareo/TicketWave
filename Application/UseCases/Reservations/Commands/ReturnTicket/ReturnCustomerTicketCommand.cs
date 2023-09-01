using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Reservations.Commands.ReturnTicket;

public class ReturnCustomerTicketCommand : IRequest<bool>
{
    public Guid ReservationId { get; set; }
}
