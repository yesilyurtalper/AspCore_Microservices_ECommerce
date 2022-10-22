
using ECommerce.Web.Models;

namespace ECommerce.Web.Services
{
    public interface IProductService : IAPIService
    {
        Task<Tout> GetProductsByCategoryIdAsync<Tout>(string url, int id);
        Task<Tout> GetProductsByBrandIdAsync<Tout>(string url, int id);
    }
}
