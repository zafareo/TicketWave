

using Application.Commons.Models;
using MediatR;

namespace Application.UseCases.Reservations.Queries;

public class GetAllReservationsQueryResponse 
{
    public Guid Id { get; set; }
    public Guid SeatId { get; set; }
    public Guid CustomerId { get; set; }
    public Guid ScheduledEventId { get; set; }
    public bool IsCancelled { get; set; }
}
