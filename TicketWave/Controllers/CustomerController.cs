using Application.Commons.Models;
using Application.UseCases.Customers.Commands;
using Application.UseCases.Customers.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using TicketWave.Services;

namespace TicketWave.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin")]
    public class CustomerController : BaseApiController
    {

        [HttpGet("[action]")]
        [LazyCache(5, 10)]
        [EnableRateLimiting("sliding")]
        public async ValueTask<ActionResult<PaginatedList<GetAllCustomersQueryResponse>>> GetAllCustomers([FromQuery] GetAllCustomersQuery query)
        {
            return await _mediator.Send(query);
        }
        [HttpPost("[action]")]
        public async ValueTask<Guid> CreateCustomer(CreateCustomerCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
