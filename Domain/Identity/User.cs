using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Identity;

public class User : BaseAuditableEntity
{
    public string FullName { get; set; }
    public string Phone { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string? Picture { get; set; }
    public virtual ICollection<Role>? Roles { get; set; }
}
