using Entities;

namespace Services
{
    public interface IProductServies
    {
        Task<IEnumerable<Product>> getProductAsync(string? desc, int? minPrice, int? maxPrice, int?[] categoryIds);
    }
}