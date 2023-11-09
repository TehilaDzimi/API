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
        public async Task<IEnumerable<Product>> getProductAsync()
        {
            //return await DB_contect.Users.Where(i => i.Email == email && i.Password == password).FirstOrDefaultAsync();
            return await DB_contect.Products.ToListAsync();
        }
    }
}
