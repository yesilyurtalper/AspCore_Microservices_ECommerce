using ECommerce.APIs.ItemAPI.Models;

namespace ECommerce.APIs.ItemAPI.Services
{
    public interface IBrandRepository : IRepository<Brand>
    {
        Task<List<Brand>> GetAllBrandsByCategoryIdAsync(int categoryId);
        Task AddCategorieAsync(int brandId, List<int> categoryIds);
        Task RemoveCategoriesAsync(int brandId, List<int> categoryIds);
        Task UpdateCategoriesAsync(int brandId, List<int> categoryIds);
    }
}
