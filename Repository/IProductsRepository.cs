using Entities;

namespace Repository
{
    public interface IProductsRepository
    {
        Task<IEnumerable<Product>> getProductAsync();
    }
}