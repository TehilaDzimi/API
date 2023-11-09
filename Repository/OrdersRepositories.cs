using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrdersRepositories : IOrdersRepositories
    {
        private readonly MyShop910Context DB_contect;
        public OrdersRepositories(MyShop910Context DBcontect)
        {
            DB_contect = DBcontect;
        }
        public async Task<Order> addOrder(Order order)
        {
            await DB_contect.Orders.AddAsync(order);
            await DB_contect.SaveChangesAsync();
            return order;
        }
    }
}
