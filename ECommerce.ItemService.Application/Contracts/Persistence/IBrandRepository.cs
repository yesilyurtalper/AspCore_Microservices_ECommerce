
using ECommerce.ItemService.Domain;

namespace ECommerce.ItemService.Application.Contracts.Persistence;
public interface IBrandRepository : IRepository<Brand>
{
    Task<List<Brand>> GetAllBrandsByCategoryIdAsync(int categoryId);
    Task AddCategoriesAsync(int brandId, List<int> categoryIds);
    Task RemoveCategoriesAsync(int brandId, List<int> categoryIds);
    Task UpdateCategoriesAsync(int brandId, List<int> categoryIds);
}