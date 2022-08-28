using Ordering.Domain.Entity;

namespace Ordering.Contracts.Persist
{
    public interface IOrderUow
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<IEnumerable<Order>> GetOrdersByUsernameAsync(string name);
        Task<Order> AddOrderAsync(Order order);
        Task<Order> UpdateOrderAsync(Order order);
        Task<Order> GetOrderByIdAsync(int id);
    }
}
