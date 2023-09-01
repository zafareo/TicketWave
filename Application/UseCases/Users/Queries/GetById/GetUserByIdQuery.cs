using Application.Commons.Exceptions;
using Application.Commons.Interfaces;
using Application.UseCases.Users.Response;
using AutoMapper;
using Domain.Identity;
using MediatR;

namespace Application.UseCases.Users.Queries.GetById;

public record GetUserByIdQuery(Guid Id) : IRequest<UserResponse>;
public class GetByIdUserResponse : IRequestHandler<GetUserByIdQuery, UserResponse>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetByIdUserResponse(IApplicationDbContext context, IMapper mapper)
           => (_context, _mapper) = (context, mapper);

    public async Task<UserResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var foundUser = await _context.Users.FindAsync(new object[] { request.Id }, cancellationToken);
        if (foundUser is null)
            throw new NotFoundException(nameof(User), request.Id);
        var result = _mapper.Map<UserResponse>(foundUser);
        return result;
    }
}
