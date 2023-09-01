using Application.Commons.Exceptions;
using Application.Commons.Extentions;
using Application.Commons.Interfaces;
using AutoMapper;
using Domain.Identity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Application.UseCases.Users.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    public CreateUserCommandHandler(IApplicationDbContext context, IMapper mapper, IConfiguration configuration)
    {
        (_context, _mapper, _configuration) = (context, mapper, configuration);

    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {

        if (_context.Users.Any(x => x.Username == request.Username))
            throw new AlreadyExistsException(nameof(User), request.Username);



        var roles = await _context.Roles.ToListAsync(cancellationToken);



        var userRole = new List<Role>();
        if (request?.RoleIds?.Length > 0)
            roles.ForEach(role =>
            {
                if (request.RoleIds.Any(id => id == role.Id))
                    userRole.Add(role);
            });


        var user = _mapper.Map<User>(request);
        user.Password = user.Password.GetHashedString();
        if (request.ProfilePicture != null)
        {
            var picturepath = _configuration["UserPicturePath"];
            string filename = user.Username + Path.GetExtension(request.ProfilePicture.FileName);
            var userImagePath = Path.Combine(picturepath, filename);

            using (var fs = new FileStream(userImagePath, FileMode.Create))
            {
                await request.ProfilePicture.CopyToAsync(fs);
                user.Picture = userImagePath;
            }
        }
        user.Roles = userRole;


        await _context.Users.AddAsync(user, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        //await _cache.RemoveAsync(_configuration["RedisKey:User"], cancellationToken);
        return user.Id;
    }
}