using AutoMapper;
using Ordering.Application.Feature.Orders.Command.CheckoutOrder;
using Ordering.Application.Feature.Orders.Command.UpdateOrder;
using Ordering.Domain.Entity;
using Ordering.Domain.Model;

namespace Ordering.Domain.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderVm>();
            CreateMap<CheckoutOrderCommand, Order>();
            CreateMap<UpdateOrderCommand, Order>();
        }
    }
}
