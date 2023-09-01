using Application.UseCases.Roles.Queries;
using AutoMapper;
using Domain.Identity;

namespace Application.Commons.Mappings;

internal class RoleMapping : Profile
{
    public RoleMapping()
    {
        CreateMap<RoleResponse, Role>().ReverseMap();
    }
}