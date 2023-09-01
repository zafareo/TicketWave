using Application.Commons.Exceptions;
using Application.Commons.Interfaces;
using Application.Commons.Models;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Rows.Queries;

public class GetAllRowsQueryHandler : IRequestHandler<GetAllRowsQuery, PaginatedList<GetAllRowsQueryResponse>>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;

    public GetAllRowsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<PaginatedList<GetAllRowsQueryResponse>> Handle(GetAllRowsQuery request, CancellationToken cancellationToken)
    {
        var pageSize = request.PageSize;
        var pageNumber = request.PageNumber;
        var searchingText = request.SearchingText?.Trim();

        var rows = _context.Rows.AsQueryable();
        if (!string.IsNullOrEmpty(searchingText))
        {
            rows = rows.Where(p => p.Number.ToString().ToLower().Contains(searchingText.ToLower()));
        }
        if (rows is null || rows.Count() <= 0)
            throw new NotFoundException(nameof(Row), searchingText);
        var paginatedRows = await PaginatedList<Row>.CreateAsync(rows, pageNumber, pageSize);

        var clientResponses = _mapper.Map<List<GetAllRowsQueryResponse>>(paginatedRows.Items);

        var result = new PaginatedList<GetAllRowsQueryResponse>(clientResponses, paginatedRows.TotalCount, request.PageNumber, request.PageSize);
        return result;
    }
}
