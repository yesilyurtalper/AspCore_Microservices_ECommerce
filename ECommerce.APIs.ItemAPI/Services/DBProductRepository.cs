using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ECommerce.APIs.ItemAPI.Models;

namespace ECommerce.APIs.ItemAPI.Services
{
    public class DBProductRepository : DBRepository<Product> , IProductRepository
    {

        public DBProductRepository(ItemAPIDbContext dbContext, IMapper mapper) : base (dbContext,mapper)
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
}


