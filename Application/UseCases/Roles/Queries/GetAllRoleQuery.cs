using MediatR;

namespace Application.UseCases.Roles.Queries;

public class GetAllRoleQuery : IRequest<List<RoleResponse>>
{
}
