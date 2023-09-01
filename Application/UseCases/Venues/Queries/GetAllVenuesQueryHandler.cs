using Application.Commons.Exceptions;
using Application.Commons.Interfaces;
using Application.Commons.Models;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Venues.Queries;

public class GetAllVenuesQueryHandler : IRequestHandler<GetAllVenuesQuery, PaginatedList<GetAllVenueQueryResponse>>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;

    public GetAllVenuesQueryHandler(IMapper mapper, IApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    public async Task<PaginatedList<GetAllVenueQueryResponse>> Handle(GetAllVenuesQuery request, CancellationToken cancellationToken)
    {
        var pageSize = request.PageSize;
        var pageNumber = request.PageNumber;
        var searchingText = request.SearchingText?.Trim();
        var Venues = _context.Venues.AsQueryable();
        if (!string.IsNullOrEmpty(searchingText))
        {
            Venues = Venues.Where(p => p.Name.ToLower().Contains(searchingText.ToLower()));
        }
        if (Venues is null || Venues.Count() <= 0)
            throw new NotFoundException(nameof(Venue), searchingText);
        var paginatedVenues = await PaginatedList<Venue>.CreateAsync(Venues, pageNumber, pageSize);
        var venueResponses = _mapper.Map<List<GetAllVenueQueryResponse>>(paginatedVenues.Items);
        var result = new PaginatedList<GetAllVenueQueryResponse>(venueResponses, paginatedVenues.TotalCount, request.PageNumber, request.PageSize);
        return result;
    }
}
