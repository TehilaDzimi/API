using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProductsService : IProductsService
    {
        IProductsRepository _ProductsRepository;
        public ProductsService(IProductsRepository ProductsRepository)
        {
            _ProductsRepository = ProductsRepository;
        }
        public async Task<IEnumerable<Product>> getProduct(string? desc, int? minPrice, int? maxPrice, int?[] categoryIds)
        {
            return await _ProductsRepository.getProductAsync(desc,minPrice,maxPrice,categoryIds);
        }
       
    }
}
