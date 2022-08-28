using AutoMapper;
using MediatR;
using Ordering.Contracts.Persist;
using Ordering.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Feature.Orders.Query.OrderList
{
    public class AllOrdersQuery : IRequest<List<OrderVm>>
    {
        public AllOrdersQuery()
        {
        }
    }

    public class AllOrdersQueryHandler : IRequestHandler<AllOrdersQuery, List<OrderVm>>
    {
        private readonly IOrderUow _orderUow;
        private readonly IMapper _mapper;
        public AllOrdersQueryHandler(IOrderUow orderUow,
            IMapper mapper)
        {
            _orderUow = orderUow;
            _mapper = mapper;
        }
        public async Task<List<OrderVm>> Handle(AllOrdersQuery request, CancellationToken cancellationToken)
        {
            // fetch orders
            var orders = await _orderUow.GetAllOrdersAsync();
            return _mapper.Map<List<OrderVm>>(orders);
        }
    }
}
