
using ECommerce.APIs.ItemAPI.Models;

namespace ECommerce.APIs.ItemAPI.Services
{
    public interface IRepository<TModel> where TModel : BaseModel
    {
        Task<List<TModel>> GetAllAsync();
        Task<TModel> GetByIdAsync(int id);
        Task<TModel> GetByNameAsync(string name);
        Task CreateAsync(TModel model);
        Task UpdateAsync(TModel model);
        Task DeleteAsync(TModel model);
        Task SaveChangesAsync();
    }
}
