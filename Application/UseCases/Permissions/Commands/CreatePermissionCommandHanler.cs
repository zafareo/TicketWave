using Application.Commons.Interfaces;
using AutoMapper;
using Domain.Identity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Permissions.Commands;

public class CreatePermissionCommandHanler : IRequestHandler<CreatePermissionCommand, List<PermissionResponse>>
{
    private IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    public CreatePermissionCommandHanler(IApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<PermissionResponse>> Handle(CreatePermissionCommand request, CancellationToken cancellationToken)
    {

        var _permissions = new List<Permission>();

        foreach (string item in request.Name)
        {
            _permissions.Add(new()
            {
                Name = item
            });
        }

        await _dbContext.Permissions.AddRangeAsync(_permissions, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        var result = _mapper.Map<List<PermissionResponse>>(_permissions);
        return result;
    }
}
