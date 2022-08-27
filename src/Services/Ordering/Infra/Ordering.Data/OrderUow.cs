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

        #region CRUD Operations

        /// Basic CRUD Operations
        #region Basic CRUD Operations

        // Get All Async
        public async Task<IEnumerable<Order>> GetAllAsync()
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

        // Get By Id

        // Add

        // Update

        // Delete

        #endregion

        /// Custom Queries/Operations
        #region Custom Queries/Operations
        // Get by Username
        public async Task<IEnumerable<Order>> GetByUsernameAsync(string username)
        {
            var orders = await _orderContext.Orders
                .Where(q=> q.UserName.Equals(username, 
                    StringComparison.InvariantCultureIgnoreCase)).ToListAsync();

            return orders;
        }
        #endregion

        #endregion
    }
}
