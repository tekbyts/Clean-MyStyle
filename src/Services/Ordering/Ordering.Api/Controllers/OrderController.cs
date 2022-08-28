using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ordering.Application.Feature.Orders.Command.CheckoutOrder;
using Ordering.Application.Feature.Orders.Command.UpdateOrder;
using Ordering.Application.Feature.Orders.Query.OrderList;
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

        [HttpGet("byUser", Name = "Get Orders by Username")]
        public async Task<ActionResult<IEnumerable<OrderVm>>> Orders(string username)
        {
            // construct query
            var query = new OrdersByUsernameQuery(username);
            var orders = await _mediator.Send(query);
            return orders;
        }

        [HttpGet("byId", Name = "Get Order by Id")]
        public async Task<ActionResult<OrderVm>> Order(int id)
        {
            // construct query
            var query = new OrderByIdQuery(id);
            var order = await _mediator.Send(query);
            return order;
        }

        [HttpPost("checkout", Name = "Checkout Order")]
        public async Task<IActionResult> Checkout(CheckoutOrderCommand checkoutCommand)
        {
            var id = await _mediator.Send(checkoutCommand);
            return CreatedAtRoute("Get Order by Id", id);
        }

        [HttpPut(Name = "Update Order")]
        public async Task Update(UpdateOrderCommand updateCommand)
        {
            await _mediator.Send(updateCommand);
        } 

    }
}
