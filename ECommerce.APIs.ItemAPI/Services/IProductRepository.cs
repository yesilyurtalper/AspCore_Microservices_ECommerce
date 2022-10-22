using ECommerce.APIs.ItemAPI.Models;

namespace ECommerce.APIs.ItemAPI.Services
{
    public interface IProductRepository : IRepository<Product> 
    {
        Task<List<Product>> GetAllProductsByBrandIdAsync(int brandId);
        Task<List<Product>> GetAllProductsByCategoryIdAsync(int categoryId);
    }
}
