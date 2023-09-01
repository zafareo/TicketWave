using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Reservation : BaseAuditableEntity
{
    public Guid SeatId { get; set; }
    public Guid CustomerId { get; set; }
    public Guid ScheduledEventId { get; set; }
    public bool IsCancelled { get; set; } = false;
    public virtual Seat Seat { get; set; }
    public virtual Customer Customer { get; set; }
    public virtual ScheduledEvent ScheduledEvent { get; set; }
}
