
using ECommerce.Web.Models;

namespace ECommerce.Web.Services
{
    public interface IAPIService
    {
        Task<Tout> GetAllItemsAsync<Tout>(string url);
        Task<Tout> GetItemByIdAsync<Tout>(string url, int id);
        Task<Tout> CreateItemAsync<Tout,Tin>(string url, Tin item);
        Task<Tout> UpdateItemAsync<Tout,Tin>(string url, Tin item);
        Task<Tout> DeleteItemAsync<Tout>(string url, int id);
        Task<Tout> SendAsync<Tout>(ApiRequest apiRequest);
    }
}
