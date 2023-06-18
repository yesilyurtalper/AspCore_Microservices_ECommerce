using Microsoft.EntityFrameworkCore;
using ECommerce.ItemService.Domain;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Infra.DBContext;

namespace ECommerce.ItemService.Infra.Services.Persistence;

public class DBProductRepository : DBRepository<Product> , IProductRepository
{

    public DBProductRepository(ItemAPIDbContext dbContext) : base (dbContext)
    {
    }

    public override async Task<List<Product>> GetAllAsync()
    {
        var models = await _dbContext.Products
            .Include(x => x.Brand)
            .Include(x => x.Category)
            .ToListAsync();

        return models;
    }

    public async Task<List<Product>> GetAllProductsByBrandIdAsync(int brandId)
    {
        var models = await _dbContext.Products
            .Include(x => x.Brand)
            .Include(x => x.Category)
            .Where(x => x.BrandId == brandId)
            .ToListAsync();

        return models;
    }

    public async Task<List<Product>> GetAllProductsByCategoryIdAsync(int categoryId)
    {
        var models = await _dbContext.Products
            .Include(x => x.Brand)
            .Include(x => x.Category)
            .Where(x => x.CategoryId == categoryId)
            .ToListAsync();

        return models;
    }

    public override async Task<Product> GetByIdAsync(int id)
    {
        var model = await _dbContext.Products
            .Include(x => x.Brand)
            .Include(x => x.Category)
            .FirstOrDefaultAsync(x => x.Id == id);

        return model;
    }

    public override async Task<Product> GetByNameAsync(string name)
    {
        var model = await _dbContext.Products
            .Include(x => x.Brand)
            .Include(x => x.Category)
            .FirstOrDefaultAsync(x => x.Name == name);

        return model;
    }
}


