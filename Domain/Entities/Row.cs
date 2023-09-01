using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Row : BaseAuditableEntity
{
    public Guid VenueId { get; set; }
    public int Number { get; set; }
    public int SeatsEachRow { get; set; }
    public virtual Venue Venue { get; set; }
}
