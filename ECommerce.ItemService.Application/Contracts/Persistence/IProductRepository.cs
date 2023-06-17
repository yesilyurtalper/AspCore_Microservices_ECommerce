using ECommerce.ItemService.Domain;

namespace ECommerce.ItemService.Application.Contracts.Persistence;

public interface IProductRepository : IRepository<Product>
{
    Task<List<Product>> GetAllProductsByBrandIdAsync(int brandId);
    Task<List<Product>> GetAllProductsByCategoryIdAsync(int categoryId);
}
