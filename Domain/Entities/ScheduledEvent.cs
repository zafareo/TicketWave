using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class ScheduledEvent : BaseAuditableEntity
{
    public Guid EventId { get; set; }
    public Guid VenueId { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public decimal Price { get; set; }
    public virtual Event Event { get; set; }
    public virtual Venue Venue { get; set; }
    public virtual ICollection<Reservation> Reservations { get; set; }
}
