using System.Text;
using ECommerce.Web.Models;
using Newtonsoft.Json;

namespace ECommerce.Web.Services
{
    public class APIService : IAPIService { 

        public IHttpClientFactory _httpFactory { get; set; }
    
        public APIService(IHttpClientFactory httpFactory)
        {
            _httpFactory = httpFactory;
        }

        public async Task<Tout> CreateItemAsync<Tout,Tin>(string url, Tin item)
        {
            return await SendAsync<Tout>(new ApiRequest
            {
                ApiMethod = StaticData.APIMethod.PUT,
                ApiUrl = url,
                Data = item,
                AccessToken = ""
            });
        }

        public async Task<Tout> DeleteItemAsync<Tout>(string url, int id)
        {
            return await SendAsync<Tout>(new ApiRequest
            {
                ApiMethod = StaticData.APIMethod.DELETE,
                ApiUrl = url + "/"+id,
                AccessToken = ""
            });
        }

        public async Task<Tout> GetAllItemsAsync<Tout>(string url)
        {
            return await SendAsync<Tout>(new ApiRequest
            {
                ApiMethod = StaticData.APIMethod.GET,
                ApiUrl = url,
                AccessToken = ""
            });
        }

        public async Task<Tout> GetItemByIdAsync<Tout>(string url, int id)
        {
            return await this.SendAsync<Tout>(new ApiRequest
            {
                ApiMethod = StaticData.APIMethod.GET,
                ApiUrl = url + "/" + id,
                AccessToken = ""
            });
        }

        public async Task<Tout> UpdateItemAsync<Tout,Tin>(string url, Tin item)
        {
            return await SendAsync<Tout>(new ApiRequest
            {
                ApiMethod = StaticData.APIMethod.POST,
                ApiUrl = url,
                Data = item,
                AccessToken = ""
            });
        }

        public async Task<Tout> SendAsync<Tout>(ApiRequest apiRequest)
        {
            try
            {
                var client = _httpFactory.CreateClient("ECommerceItemAPI");
                var message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.ApiUrl);
                client.DefaultRequestHeaders.Clear();
                if (apiRequest.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data),
                        Encoding.UTF8, "application/json");
                }

                switch (apiRequest.ApiMethod)
                {
                    case StaticData.APIMethod.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case StaticData.APIMethod.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case StaticData.APIMethod.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }

                var apiResponse = await client.SendAsync(message);
                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                var apiResponseDto = JsonConvert.DeserializeObject<Tout>(apiContent);
                return apiResponseDto;
            }
            catch (Exception ex)
            {
                var dto = new ResponseDto
                {
                    DisplayMessage = "Error",
                    ErrorMessages = new List<string> { ex.Message },
                    IsSuccess = false
                };
                var res = JsonConvert.SerializeObject(dto);
                var apiResponseDto = JsonConvert.DeserializeObject<Tout>(res);
                return apiResponseDto;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
