using System.Text;
using ECommerce.Web.Models;
using Newtonsoft.Json;

namespace ECommerce.Web.Services
{
    public class BrandService : APIService, IBrandService
    { 

        public BrandService(IHttpClientFactory httpFactory) : base(httpFactory)
        {
        }

        public async Task<Tout> GetBrandsByCategoryIdAsync<Tout>(string url, int id)
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
