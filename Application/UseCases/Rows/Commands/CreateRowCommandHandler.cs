using Application.Commons.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Rows.Commands;

public class CreateRowCommandHandler : IRequestHandler<CreateRowCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    private readonly IMapper _mapper;
    public CreateRowCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Guid> Handle(CreateRowCommand request, CancellationToken cancellationToken)
    {
        Row row = _mapper.Map<Row>(request);
        await _context.Rows.AddAsync(row);
        await _context.SaveChangesAsync();
        return row.Id;
    }

}
