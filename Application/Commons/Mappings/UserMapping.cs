using Application.UseCases.Users.Commands.CreateUser;
using Application.UseCases.Users.Commands.RegisterUser;
using Application.UseCases.Users.Response;
using AutoMapper;
using Domain.Identity;

namespace Application.Commons.Mappings;

public class UserMapping : Profile
{
    public UserMapping()
    {
        CreateMap<UserResponse, User>().ReverseMap()
            .ForMember(dest => dest.RoleNames, opt => opt.MapFrom(src => src.Roles.Select(x => x.Name)));

        CreateMap<RegisterUserCommand, User>().ReverseMap();
        CreateMap<CreateUserCommand, User>().ReverseMap();
    }
}
