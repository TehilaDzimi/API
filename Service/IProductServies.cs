using Entities;

namespace Services
{
    public interface IProductServies
    {
        Task<IEnumerable<Product>> getProductAsync();
    }
}