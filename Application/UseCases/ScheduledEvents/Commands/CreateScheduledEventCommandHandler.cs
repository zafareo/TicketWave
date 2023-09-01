using Application.Commons.Exceptions;
using Application.Commons.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.ScheduledEvents.Commands;

public class CreateScheduledEventCommandHandler : IRequestHandler<CreateScheduledEventCommand, Guid>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public CreateScheduledEventCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateScheduledEventCommand request, CancellationToken cancellationToken)
    {

        ScheduledEvent _event = _mapper.Map<ScheduledEvent>(request);
        bool isInterval = !_dbContext.ScheduledEvents.Any(e =>
           e.VenueId == request.VenueId &&
           !(request.End <= e.Start || request.Start >= e.End) &&
           (request.Start - e.End).TotalHours < 1 &&
           (e.Start - request.End).TotalHours < 1);
        if (isInterval)
        {
            await _dbContext.ScheduledEvents.AddAsync(_event, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return _event.Id;

        }
        throw new NotFoundException(nameof(ScheduledEvent), "The time doesn't match");
    }
}
