using Entities;

namespace Repository
{
    public interface IOrdersRepositories
    {
        Task<Order> addOrder(Order order);
        Task<int> GetProductsPrice(OrderItem orderItems);
    }
}