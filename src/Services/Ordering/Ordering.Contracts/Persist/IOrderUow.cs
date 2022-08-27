using Ordering.Domain.Entity;

namespace Ordering.Contracts.Persist
{
    public interface IOrderUow
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<IEnumerable<Order>> GetByUsernameAsync(string name);
    }
}
