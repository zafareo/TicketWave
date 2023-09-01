using Application.Commons.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Venues.Commands;

public class CreateVenueCommandHandler : IRequestHandler<CreateVenueCommand, Guid>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreateVenueCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Guid> Handle(CreateVenueCommand request, CancellationToken cancellationToken)
    {
        Venue venue = _mapper.Map<Venue>(request);
        await _context.Venues.AddAsync(venue);
        await _context.SaveChangesAsync(cancellationToken);
        return venue.Id;
    }
}
