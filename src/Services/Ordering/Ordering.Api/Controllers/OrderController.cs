using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ordering.App.Feature.Order.Query.OrderList;
using Ordering.Domain.Model;

namespace Ordering.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("", Name = "Get All Orders")]
        public async Task<ActionResult<IEnumerable<OrderVm>>> Orders()
        {
            // construct query
            var query = new AllOrdersQuery();
            var orders = await _mediator.Send(query);
            return orders;
        }

        [HttpGet("{username}", Name = "Get Orders by Username")]
        public async Task<ActionResult<IEnumerable<OrderVm>>> Orders(string username)
        {
            // construct query
            var query = new OrdersByUsernameQuery(username);
            var orders = await _mediator.Send(query);
            return orders;
        }
    }
}
