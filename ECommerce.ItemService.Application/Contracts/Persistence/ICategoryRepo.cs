using ECommerce.ItemService.Domain;

namespace ECommerce.ItemService.Application.Contracts.Persistence;

public interface ICategoryRepo : IBaseItemRepo<Category>
{
    Task<List<Category>> GetCategoriesByBrandIdAsync(int brandId);

    Task<List<Category>> GetCategoriesOutOfBrandIdAsync(int brandId);
}
