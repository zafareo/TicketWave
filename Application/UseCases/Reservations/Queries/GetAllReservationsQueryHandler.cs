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

namespace Application.UseCases.Reservations.Queries;

public class GetAllReservationsQueryHandler : IRequestHandler<GetAllReservationsQuery, PaginatedList<GetAllReservationsQueryResponse>>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;

    public GetAllReservationsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<PaginatedList<GetAllReservationsQueryResponse>> Handle(GetAllReservationsQuery request, CancellationToken cancellationToken)
    {
        var pageSize = request.PageSize;
        var pageNumber = request.PageNumber;
        var searchingText = request.SearchingText?.Trim();

        var reservations = _context.Reservations.AsQueryable();
        if (!string.IsNullOrEmpty(searchingText))
        {
            reservations = reservations.Where(p => p.ScheduledEventId.ToString().ToLower().Contains(searchingText.ToLower()));
        }
        if (reservations is null || reservations.Count() <= 0)
            throw new NotFoundException(nameof(Reservation), searchingText);
        var paginatedReservations = await PaginatedList<Reservation>.CreateAsync(reservations, pageNumber, pageSize);

        var reservationResponses = _mapper.Map<List<GetAllReservationsQueryResponse>>(paginatedReservations.Items);

        var result = new PaginatedList<GetAllReservationsQueryResponse>(reservationResponses, paginatedReservations.TotalCount, request.PageNumber, request.PageSize);
        return result;

    }
}
