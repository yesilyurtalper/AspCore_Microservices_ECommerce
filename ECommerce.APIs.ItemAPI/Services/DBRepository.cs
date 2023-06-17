using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ECommerce.ItemService.Domain;
using ECommerce.APIs.ItemAPI.Models;

namespace ECommerce.APIs.ItemAPI.Services
{
    public class DBRepository<TModel> : IRepository<TModel> where TModel : BaseItem
    {
        protected readonly ItemAPIDbContext _dbContext;
        protected DbSet<TModel> _dbSet = null;
        protected IMapper _mapper;

        public DBRepository(ItemAPIDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _dbSet = _dbContext.Set<TModel>();
        }

        public virtual async Task CreateAsync(TModel model)
        {
            await _dbSet.AddAsync(model);
        }

        public virtual async Task UpdateAsync(TModel model)
        {
            await Task.Run(() => 
            {
                _dbSet.Update(model);
            });
        }

        public virtual async Task DeleteAsync(TModel model)
        {
            await Task.Run( () => _dbSet.Remove(model));
        }

        public virtual async Task<TModel> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id); 
        }

        public virtual async Task<TModel> GetByNameAsync(string name)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Name == name);
        }

        public virtual async Task<List<TModel>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
