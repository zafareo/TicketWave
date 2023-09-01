using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Permissions.Commands;

public class CreatePermissionCommand : IRequest<List<PermissionResponse>>
{
    public string[] Name { get; set; }
}
