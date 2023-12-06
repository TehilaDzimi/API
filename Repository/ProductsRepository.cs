using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly MyShop910Context DB_contect;
        public ProductsRepository(MyShop910Context DBcontect)
        {
            DB_contect = DBcontect;
        }


        public async Task<IEnumerable<Product>> getProductAsync(string? desc, int? minPrice, int? maxPrice, int?[] categoryIds)
        {
            var query = DB_contect.Products.Where(products =>
            (desc == null ? (true) : (products.Description.Contains(desc)))
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
