using ECommerce.ItemService.Domain;

namespace ECommerce.ItemService.Application.Contracts.Persistence;

public interface IProductRepo : IBaseItemRepo<Product>
{
    Task<List<Product>> GetProductsByBrandIdAsync(int brandId);
    Task<List<Product>> GetProductsByCategoryIdAsync(int categoryId);
}
