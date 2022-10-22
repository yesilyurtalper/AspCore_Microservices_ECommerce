using System.Text;
using ECommerce.Web.Models;
using Newtonsoft.Json;

namespace ECommerce.Web.Services
{
    public class CategoryService : APIService, ICategoryService
    { 

        public CategoryService(IHttpClientFactory httpFactory) : base(httpFactory)
        {
        }

        public async Task<Tout> GetCategoriesByBrandIdAsync<Tout>(string url, int id)
        {
            return await SendAsync<Tout>(new ApiRequest
            {
                ApiMethod = StaticData.APIMethod.GET,
                ApiUrl = url+"/"+id,
                AccessToken = ""
            });
        }
    }
}
