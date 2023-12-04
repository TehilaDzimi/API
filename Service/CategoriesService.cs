using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoriesRepository _ICategoriesRepository;

        public CategoriesService(ICategoriesRepository ICategoriesRepository)
        {
            _ICategoriesRepository = ICategoriesRepository;
        }
        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _ICategoriesRepository.GetCategoriesAsync();
        }

    }
}
