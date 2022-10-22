
using ECommerce.Web.Models;

namespace ECommerce.Web.Services
{
    public interface IItemService
    {
        Task<Tout> GetAsync<Tout>(string relativeUrl, string accessToken);
        Task<Tout> CreateItemAsync<Tout,Tin>(string relativeUrl, Tin item, string accessToken);
        Task<Tout> UpdateItemAsync<Tout,Tin>(string relativeUrl, Tin item, string accessToken);
        Task<Tout> DeleteItemAsync<Tout>(string relativeUrl, int id, string accessToken);
    }
}
