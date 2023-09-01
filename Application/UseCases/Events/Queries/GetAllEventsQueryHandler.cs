using Application.Commons.Exceptions;
using Application.Commons.Interfaces;
using Application.Commons.Models;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Events.Queries;

public class GetAllEventsQueryHandler : IRequestHandler<GetAllEventsQuery, PaginatedList<GetAllEventsQueryResponse>>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;

    public GetAllEventsQueryHandler(IMapper mapper, IApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    public async Task<PaginatedList<GetAllEventsQueryResponse>> Handle(GetAllEventsQuery request, CancellationToken cancellationToken)
    {
        var pageSize = request.PageSize;
        var pageNumber = request.PageNumber;
        var searchingText = request.SearchingText?.Trim();

        var events = _context.Events.AsQueryable();
        if (!string.IsNullOrEmpty(searchingText))
        {
            events = events.Where(x => x.Description.ToLower().Contains(searchingText.ToLower()));
        }
        if (events is null || events.Count() <= 0)
            throw new NotFoundException(nameof(Event), searchingText);
        var paginatedEvents = await PaginatedList<Event>.CreateAsync(events, pageNumber, pageSize);
        var evetResponses = _mapper.Map<List<GetAllEventsQueryResponse>>(paginatedEvents.Items);
        var result = new PaginatedList<GetAllEventsQueryResponse>(evetResponses, paginatedEvents.TotalCount, request.PageNumber, request.PageSize);
        return result;
    }
}
