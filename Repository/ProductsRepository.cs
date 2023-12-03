using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly MyShop910Context _dbContect;
        public ProductsRepository(MyShop910Context DBcontect)
        {
            _dbContect = DBcontect;
        }
        public async Task<IEnumerable<Product>> getProductAsync(string? desc, int? minPrice, int? maxPrice, int?[] categoryIds)
        {
            var query = _dbContect.Products.Where(products =>
            (desc == null ? (true) : (products.Name.Contains(desc)))
            && ((minPrice == null) ? (true) : (products.Price >= minPrice))
            && ((maxPrice == null) ? (true) : (products.Price <= maxPrice))
            && ((categoryIds.Length == 0) ? (true) : (categoryIds.Contains(products.CategoryId))))
                .OrderBy(products => products.Price);
            Console.WriteLine(query.ToQueryString());
            List<Product> products = await query.ToListAsync();
            return products;
        }
    }
}
