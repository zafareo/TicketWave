using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Permissions;

public class PermissionResponse
{
    public Guid PermissionId { get; set; }
    public string PermissionName { get; set; }
}
