﻿using Application.UseCases.Permissions;
using AutoMapper;
using Domain.Identity;

namespace Application.Commons.Mappings;

public class PermissionMapping : Profile
{
    public PermissionMapping()
    {
        CreateMap<Permission, PermissionResponse>()
            .ForMember(x => x.PermissionId, o => o.MapFrom(x => x.Id))
            .ForMember(x => x.PermissionName, o => o.MapFrom(x => x.Name));
    }
}