using Entities;

namespace Service
{
    public interface IOrdersService
    {
        Task<Order> addOrder(Order order);
        
    }
}