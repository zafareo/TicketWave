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

namespace Application.UseCases.Customers.Queries
{
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, PaginatedList<GetAllCustomersQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetAllCustomersQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<GetAllCustomersQueryResponse>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var pageSize = request.PageSize;
            var pageNumber = request.PageNumber;
            var searchingText = request.SearchingText?.Trim();

            var customers = _context.Customers.AsQueryable();
            if (!string.IsNullOrEmpty(searchingText))
            {
                customers = customers.Where(p => p.FirstName.ToLower().Contains(searchingText.ToLower()));
            }
            if (customers is null || customers.Count() <= 0)
                throw new NotFoundException(nameof(Customer), searchingText);
            var paginatedCustomers = await PaginatedList<Customer>.CreateAsync(customers, pageNumber, pageSize);

            var customerResponses = _mapper.Map<List<GetAllCustomersQueryResponse>>(paginatedCustomers.Items);

            var result = new PaginatedList<GetAllCustomersQueryResponse>(customerResponses, paginatedCustomers.TotalCount, request.PageNumber, request.PageSize);
            return result;

        }
    }
}
