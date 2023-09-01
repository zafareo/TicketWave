using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Roles.Commands;

public class CreateRoleCommand : IRequest<Guid>
{
    public string Name { get; set; }
    public List<Guid>? PermissionsIds { get; set; }
}
