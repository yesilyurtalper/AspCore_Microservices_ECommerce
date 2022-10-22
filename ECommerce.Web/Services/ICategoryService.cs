
using ECommerce.Web.Models;

namespace ECommerce.Web.Services
{
    public interface ICategoryService : IAPIService
    {
        Task<Tout> GetCategoriesByBrandIdAsync<Tout>(string url, int id);
    }
}
