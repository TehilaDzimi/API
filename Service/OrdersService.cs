using Entities;
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
        IOrdersRepositories orderRepository;

        public OrdersService(IOrdersRepositories o)
        {
            orderRepository = o;
        }

        public async Task<Order> addOrder(Order order)
        {
            return await orderRepository.addOrder(order);
        }

    }
}
