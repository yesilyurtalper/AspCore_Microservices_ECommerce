using ECommerce.ItemService.Domain;

namespace ECommerce.APIs.ItemAPI.Services
{
    public interface IProductRepository : IRepository<Product> 
    {
        Task<List<Product>> GetAllProductsByBrandIdAsync(int brandId);
        Task<List<Product>> GetAllProductsByCategoryIdAsync(int categoryId);
    }
}
