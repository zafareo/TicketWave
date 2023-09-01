using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Seats.Queries.EmptySeats
{
    public class GetAllEmptySeatsQueryResponse
    {
        public Guid Id { get; set; }
        public Guid RowId { get; set; }
        public int Number { get; set; }
    }
}
