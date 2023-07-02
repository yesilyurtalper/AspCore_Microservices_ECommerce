
using ECommerce.ItemService.Domain;

namespace ECommerce.ItemService.Application.Contracts.Persistence;

public interface IBaseItemRepo<TModel> where TModel : BaseItem
{
    Task<List<TModel>> GetAllAsync();
    Task<TModel> GetByIdAsync(int id);
    Task<TModel> GetByNameAsync(string name);
    Task CreateAsync(TModel model);
    Task UpdateAsync(TModel model);
    Task DeleteAsync(TModel model);
}
