using AutoMapper;
using MediatR;
using Ordering.Contracts.Persist;
using Ordering.Domain.Model;

namespace Ordering.Application.Feature.Orders.Query.OrderList
{
    public class OrderByIdQuery : IRequest<OrderVm>
    {
        public int Id { get; set; }

        public OrderByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class OrderByIdQueryHandler : IRequestHandler<OrderByIdQuery, OrderVm>
    {
        private readonly IOrderUow _orderUow;
        private readonly IMapper _mapper;
        public OrderByIdQueryHandler(IOrderUow orderUow,
            IMapper mapper)
        {
            _orderUow = orderUow;
            _mapper = mapper;
        }

        public async Task<OrderVm> Handle(OrderByIdQuery request, CancellationToken cancellationToken)
        {
            // fetch order
            var order = await _orderUow.GetOrderByIdAsync(request.Id);
            return _mapper.Map<OrderVm>(order);
        }
    }
}
