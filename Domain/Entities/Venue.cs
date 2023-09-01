﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Venue : BaseAuditableEntity
{
    public string Name { get; set; }
    public string Address { get; set; }
    public int Capacity { get; set; }
    public virtual ICollection<Event> Events { get; set; }
    public virtual ICollection<Row> Rows { get; set; }

}
