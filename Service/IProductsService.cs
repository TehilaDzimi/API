using Entities;

namespace Service
{
    public interface IProductsService
    {
        Task<IEnumerable<Product>> getProduct(string? desc, int? minPrice, int? maxPrice, int?[] categoryIds);
    }
}