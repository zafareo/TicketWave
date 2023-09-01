using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Identity;

public class Role : BaseAuditableEntity
{
    public string Name { get; set; }
    public virtual ICollection<Permission> Permissions { get; set; }
    [JsonIgnore]
    public virtual ICollection<User>? Users { get; set; }
}
