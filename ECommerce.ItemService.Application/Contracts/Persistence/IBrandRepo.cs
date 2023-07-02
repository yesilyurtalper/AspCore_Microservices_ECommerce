
using ECommerce.ItemService.Domain;

namespace ECommerce.ItemService.Application.Contracts.Persistence;
public interface IBrandRepo : IBaseItemRepo<Brand>
{
    Task<List<Brand>> GetBrandsByCategoryIdAsync(int categoryId);
    Task AddBrandCategoriesAsync(int brandId, List<int> categoryIds);
    Task RemoveBrandCategoriesAsync(int brandId, List<int> categoryIds);
    Task UpdateBrandCategoriesAsync(int brandId, List<int> categoryIds);
}