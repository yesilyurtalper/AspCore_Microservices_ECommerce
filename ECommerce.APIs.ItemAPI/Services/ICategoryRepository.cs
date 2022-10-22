using ECommerce.APIs.ItemAPI.Models;

namespace ECommerce.APIs.ItemAPI.Services
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<List<Category>> GetAllCategoriesByBrandIdAsync(int brandId);

        Task<List<Category>> GetAllCategoriesOutOfBrandIdAsync(int brandId);
    }
}
