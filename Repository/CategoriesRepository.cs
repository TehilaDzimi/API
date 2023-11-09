using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static Repository.CategoryRepository;

namespace Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MyShop910Context _MyShop910Context;

        public CategoryRepository(MyShop910Context MyShop910Context)
        {
            _MyShop910Context = MyShop910Context;
        }

        public async Task<IEnumerable<Category>> GetCategoryAsync()
        {
            return await _MyShop910Context.Categories.ToListAsync();
        }
    }

}
