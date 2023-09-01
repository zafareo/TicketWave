using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Rows.Queries
{
    public class GetAllRowsQueryResponse
    {
        public Guid Id { get; set; }
        public Guid VenueId { get; set; }
        public int Number { get; set; }
        public int SeatsEachRow { get; set; }
    }
}
