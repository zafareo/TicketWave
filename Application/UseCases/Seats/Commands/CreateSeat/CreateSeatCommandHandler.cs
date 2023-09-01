using Application.Commons.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Seats.Commands.CreateSeat;

public class CreateSeatCommandHandler : IRequestHandler<CreateSeatCommand, Guid>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreateSeatCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Guid> Handle(CreateSeatCommand request, CancellationToken cancellationToken)
    {
        Seat seat = _mapper.Map<Seat>(request);
        await _context.Seats.AddAsync(seat);
        await _context.SaveChangesAsync();
        return seat.Id;
    }
}
