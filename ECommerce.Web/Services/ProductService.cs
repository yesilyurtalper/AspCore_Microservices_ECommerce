using System.Text;
using ECommerce.Web.Models;
using Newtonsoft.Json;

namespace ECommerce.Web.Services
{
    public class ProductService : APIService, IProductService
    { 

        public ProductService(IHttpClientFactory httpFactory) : base(httpFactory)
        {
        }

        public async Task<Tout> GetProductsByCategoryIdAsync<Tout>(string url, int id)
        {
            return await SendAsync<Tout>(new ApiRequest
            {
                ApiMethod = StaticData.APIMethod.GET,
                ApiUrl = url+"/"+id,
                AccessToken = ""
            });
        }

        public async Task<Tout> GetProductsByBrandIdAsync<Tout>(string url, int id)
        {
            return await SendAsync<Tout>(new ApiRequest
            {
                ApiMethod = StaticData.APIMethod.GET,
                ApiUrl = url + "/" + id,
                AccessToken = ""
            });
        }
    }
}
