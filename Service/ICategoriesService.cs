using Entities;

namespace Service
{
    public interface ICategoriesService
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
    }
}