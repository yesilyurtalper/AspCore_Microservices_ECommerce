
using ECommerce.ItemService.Domain;
using ECommerce.ItemService.Infra.DBContext;
using ECommerce.ItemService.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.ItemService.Infra.Services.Persistence;

public class DBBaseItemRepo<TModel> : IBaseItemRepo<TModel> where TModel : BaseItem
{
    protected readonly ItemAPIDbContext _dbContext;
    protected DbSet<TModel> _dbSet = null;

    public DBBaseItemRepo(ItemAPIDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<TModel>();
    }

    public virtual async Task CreateAsync(TModel model)
    {
        await _dbSet.AddAsync(model);
        await _dbContext.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(TModel model)
    {
        _dbSet.Update(model);
        await _dbContext.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(TModel model)
    {
        _dbSet.Remove(model);
        await _dbContext.SaveChangesAsync();
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
}
