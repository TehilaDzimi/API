using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrdersRepositories : IOrdersRepositories
    {
        private readonly MyShop910Context _DB_contect;
        public OrdersRepositories(MyShop910Context DB_contect)
        {
            _DB_contect = DB_contect;
        }


        public async Task<Order> addOrder(Order order)
        {
            await _DB_contect.Orders.AddAsync(order);
            await _DB_contect.SaveChangesAsync();

            return order;

        }

        public async Task<int> GetProductsPrice(OrderItem orderItems)
        {
            Product p = _DB_contect.Products.Where(i => i.ProductId == orderItems.ProductsId).FirstOrDefault();
            return (int)p.Price;
        }
    }
}
