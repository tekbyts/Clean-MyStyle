using AutoMapper;
using Ordering.Domain.Entity;
using Ordering.Domain.Model;

namespace Ordering.Domain.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderVm>();
        }
    }
}
