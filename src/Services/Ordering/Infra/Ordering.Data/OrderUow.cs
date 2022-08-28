using Microsoft.EntityFrameworkCore;
using Ordering.Contracts.Persist;
using Ordering.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Data
{
    public class OrderUow : IOrderUow
    {
        private readonly OrderDbContext _orderContext;
        public OrderUow(OrderDbContext orderContext)
        {
            _orderContext = orderContext;
        }

        #region Basic CRUD Operations - Orders

        // Get All Orders Async
        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            var canConnect = await _orderContext.Database.CanConnectAsync();
            IEnumerable<Order> orders = new List<Order>();
            try
            {
                orders = await _orderContext.Orders.ToListAsync();
            }
            catch (Exception ex)
            {
                ;
            }
            
            return orders;
        }

        // Get Order By Id
        public async Task<Order> GetOrderByIdAsync(int id)
        {
            var oder = await _orderContext.Orders.FindAsync(id);
            return oder;
        }

        // Add
        public async Task<Order> AddOrderAsync(Order order)
        {
            try
            {
                await _orderContext.Orders.AddAsync(order);
                await _orderContext.SaveChangesAsync();                
            }
            catch (Exception ex)
            {

            }
            return order;
        }

        // Update
        public async Task<Order> UpdateOrderAsync(Order order)
        {
            _orderContext.Orders.Update(order);
            await _orderContext.SaveChangesAsync();
            return await Task.FromResult(order);
        }

        // Delete

        #endregion Basic CRUD Operations - Orders

        #region Custom Queries/Operations - Orders
        // Get by Username
        public async Task<IEnumerable<Order>> GetOrdersByUsernameAsync(string username)
        {
            var orders = await _orderContext.Orders
                .Where(q=> q.UserName.Equals(username)).ToListAsync();

            return orders;
        }
        #endregion Custom Queries/Operations - Orders
    }
}
