using Application.Commons.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Customers.Queries
{
    public class GetAllCustomersQuery : IRequest<PaginatedList<GetAllCustomersQueryResponse>>
    {
        public string? SearchingText { get; set; }
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;
    }
}
