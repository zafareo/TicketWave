using Application.Commons.Exceptions;
using Application.Commons.Interfaces;
using Application.Commons.Models;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Seats.Queries.AllSeats;

public class GetAllSeatsQueryHandler : IRequestHandler<GetAllSeatsQuery, PaginatedList<GetAllSeatsQueryResponse>>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;

    public GetAllSeatsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<PaginatedList<GetAllSeatsQueryResponse>> Handle(GetAllSeatsQuery request, CancellationToken cancellationToken)
    {
        var pageSize = request.PageSize;
        var pageNumber = request.PageNumber;
        var searchingText = request.SearchingText?.Trim();

        var seats = _context.Seats.AsQueryable();
        if (!string.IsNullOrEmpty(searchingText))
        {
            seats = seats.Where(p => p.Number.ToString().ToLower().Contains(searchingText.ToLower()));
        }
        if (seats is null || seats.Count() <= 0)
            throw new NotFoundException(nameof(Seat), searchingText);
        var paginatedSeats = await PaginatedList<Seat>.CreateAsync(seats, pageNumber, pageSize);

        var seatResponses = _mapper.Map<List<GetAllSeatsQueryResponse>>(paginatedSeats.Items);

        var result = new PaginatedList<GetAllSeatsQueryResponse>(seatResponses, paginatedSeats.TotalCount, request.PageNumber, request.PageSize);
        return result;
    }
}
