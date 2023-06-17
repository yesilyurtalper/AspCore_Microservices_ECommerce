using ECommerce.ItemService.Domain;

namespace ECommerce.ItemService.Application.Contracts.Persistence;

public interface ICategoryRepository : IRepository<Category>
{
    Task<List<Category>> GetAllCategoriesByBrandIdAsync(int brandId);

    Task<List<Category>> GetAllCategoriesOutOfBrandIdAsync(int brandId);
}
