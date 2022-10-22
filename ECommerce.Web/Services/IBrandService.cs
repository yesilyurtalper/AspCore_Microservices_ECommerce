
using ECommerce.Web.Models;

namespace ECommerce.Web.Services
{
    public interface IBrandService : IAPIService
    {
        Task<Tout> GetBrandsByCategoryIdAsync<Tout>(string url, int id);
    }
}
