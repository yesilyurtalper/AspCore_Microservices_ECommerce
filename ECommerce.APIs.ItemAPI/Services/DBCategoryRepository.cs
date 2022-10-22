using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ECommerce.APIs.ItemAPI.Models;

namespace ECommerce.APIs.ItemAPI.Services
{
    public class DBCategoryRepository : DBRepository<Category>, ICategoryRepository
    {

        public DBCategoryRepository(ItemAPIDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
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
}


