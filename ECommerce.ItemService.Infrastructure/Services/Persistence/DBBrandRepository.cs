
using ECommerce.ItemService.Infra.DBContext;
using ECommerce.ItemService.Domain;
using ECommerce.ItemService.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.ItemService.Infra.Services.Persistence;

public class DBBrandRepository : DBRepository<Brand>, IBrandRepository
{

    public DBBrandRepository(ItemAPIDbContext dbContext) : base(dbContext)
    {
    }

    //public override async Task<List<Brand>> GetAllAsync()
    //{
    //    var models = await _dbContext.Brands
    //        .Include(x => x.BrandCategories)
    //        .ThenInclude(x => x.Category)
    //        .ToListAsync();

    //    return models;
    //}

    public async Task<List<Brand>> GetAllBrandsByCategoryIdAsync(int categoryId)
    {
        var entities = await _dbContext.BrandCategories
            .Where(x => x.CategoryId == categoryId)
            .Include(x => x.Brand)
            //.ThenInclude(x => x.BrandCategories)
            //.ThenInclude(x => x.Category)
            .Select(x => x.Brand)
            .ToListAsync();

        return entities;
    }

    //public override async Task<Brand> GetByIdAsync(int id)
    //{
    //    var entity = await _dbContext.Brands
    //        .Where(x => x.Id == id)
    //        .Include(x => x.Products)
    //        .Include(x => x.BrandCategories)
    //        .ThenInclude(x => x.Category)
    //        .FirstOrDefaultAsync();

    //    return entity;
    //}

    //public override async Task<Brand> GetByNameAsync(string name)
    //{
    //    var model = await _dbContext.Brands
    //        .Where(x => x.Name == name)
    //        .Include(x => x.BrandCategories)
    //        .ThenInclude(x => x.Category)
    //        .FirstOrDefaultAsync();

    //    return model;
    //}

    public async Task AddCategoriesAsync(int brandId, List<int> categoryIds)
    {
        var added = categoryIds.Select(x => new BrandCategory { BrandId = brandId, CategoryId = x });
        await _dbContext.BrandCategories.AddRangeAsync(added);
    }

    public async Task RemoveCategoriesAsync(int brandId, List<int> categoryIds)
    {
        var removed = categoryIds.Select(x => new BrandCategory { BrandId = brandId, CategoryId = x });
        await Task.Run(() => _dbContext.BrandCategories.RemoveRange(removed));
    }

    public async Task UpdateCategoriesAsync(int brandId, List<int> categoryIds)
    {
        var removed =  await _dbContext.BrandCategories.Where(x => x.BrandId == brandId).ToListAsync();
        await Task.Run(() => _dbContext.BrandCategories.RemoveRange(removed));

        var added = categoryIds.Select(x => new BrandCategory { BrandId = brandId, CategoryId = x });
        await _dbContext.AddRangeAsync(added);
    }
}


