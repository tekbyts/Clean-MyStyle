using AutoMapper;
using MediatR;
using Ordering.Contracts.Persist;
using Ordering.Domain.Model;

namespace Ordering.Application.Feature.Order.Query.OrderList
{
    public class OrdersByUsernameQuery : IRequest<List<OrderVm>>
    {
        public string Username { get; set; }

        public OrdersByUsernameQuery(string username)
        {
            Username = username;
        }
    }

    public class OrdersByUsernameQueryHandler : IRequestHandler<OrdersByUsernameQuery, List<OrderVm>>
    {
        private readonly IOrderUow _orderUow;
        private readonly IMapper _mapper;
        public OrdersByUsernameQueryHandler(IOrderUow orderUow,
            IMapper mapper)
        {
            _orderUow = orderUow;
            _mapper = mapper;
        }
        public async Task<List<OrderVm>> Handle(OrdersByUsernameQuery request, CancellationToken cancellationToken)
        {
            // fetch orders
            var orders = await _orderUow.GetByUsernameAsync(request.Username);
            return _mapper.Map<List<OrderVm>>(orders);
        }
    }
}
