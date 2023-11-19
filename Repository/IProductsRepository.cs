using Entities;

namespace Repository
{
    public interface IProductsRepository
    {
        Task<IEnumerable<Product>> getProductAsync(string? desc, int? minPrice, int? maxPrice, int?[] categoryIds);
    }
}