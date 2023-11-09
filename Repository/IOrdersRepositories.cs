using Entities;

namespace Repository
{
    public interface IOrdersRepositories
    {
        Task<Order> addOrder(Order order);
    }
}