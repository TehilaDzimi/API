using Entities;
using Microsoft.Extensions.Logging;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class OrdersService : IOrdersService
    {
        IOrdersRepositories _OrdersRepositories;
        ILogger<OrdersService> _logger;
        public OrdersService(IOrdersRepositories OrdersRepositories, ILogger<OrdersService> logger)
        {
            _OrdersRepositories = OrdersRepositories;
            
        }
        public async Task<Order> addOrder(Order order)
        {
            int sum = 0;
            IEnumerable<OrderItem> items = order.OrderItems;
            foreach (OrderItem item in items)
            {
                sum += await _OrdersRepositories.GetProductsPrice(item);

            }
            if (sum != order.OrderSum)
            {
                _logger.LogError("hi! the sum dont match!");
                order.OrderSum = sum;
            }
            
            return await _OrdersRepositories.addOrder(order);
        }

        
    }
}
