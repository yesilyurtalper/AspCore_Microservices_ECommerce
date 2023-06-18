
using Microsoft.EntityFrameworkCore;
using ECommerce.ItemService.Domain;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Infra.DBContext;

namespace ECommerce.ItemService.Infra.Services.Persistence;

public class DBCategoryRepository : DBRepository<Category>, ICategoryRepository
{

    public DBCategoryRepository(ItemAPIDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<Category>> GetAllCategoriesByBrandIdAsync(int brandId)
    {
        var entities = await _dbContext.BrandCategories
            .Where(x => x.BrandId == brandId)
            .Include(x => x.Category)
            .Select(x => x.Category)
            .ToListAsync();

        return entities;
    }

    public async Task<List<Category>> GetAllCategoriesOutOfBrandIdAsync(int brandId)
    {
        var brandCats = await GetAllCategoriesByBrandIdAsync(brandId);
        var allCats = await GetAllAsync();
        foreach (var cat in brandCats)
            allCats.Remove(cat);
        return allCats;
    }
}


