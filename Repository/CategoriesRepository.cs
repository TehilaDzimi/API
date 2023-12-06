using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly MyShop910Context DB_contect;
        public CategoriesRepository(MyShop910Context _DB_contect)
        {
            DB_contect = _DB_contect;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await DB_contect.Categories.ToListAsync();
        }

    }
}
