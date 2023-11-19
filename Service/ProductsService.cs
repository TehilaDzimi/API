using Entities;
using Repository;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
namespace Services
{
    public class ProductServies : IProductServies
    {
        IProductsRepository _productRepository;

        public ProductServies(IProductsRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IEnumerable<Product>> getProductAsync(string? desc, int? minPrice, int? maxPrice, int?[] categoryIds)
        {
            return await _productRepository.getProductAsync(desc,minPrice,maxPrice,categoryIds);
        }

    }
}
