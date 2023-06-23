using System.Text;
using ECommer.ItemUI.Models;
using Newtonsoft.Json;
using static ECommer.ItemUI.StaticData;

namespace ECommer.ItemUI.Services
{
    public class BaseService : IBaseService
    {
        public ResponseDto responseModel { get; set; }
        public IHttpClientFactory _httpFactory { get; set; }

        public APIClient APIClient ;

        public BaseService(IHttpClientFactory httpFactory, APIClient apiClient)
        {
            responseModel = new ResponseDto();
            _httpFactory = httpFactory;
            APIClient = apiClient;
        }

        public async Task<Tout> SendAsync<Tout>(ApiRequest apiRequest)
        {
            try
            {
                var client = _httpFactory.CreateClient(APIClient.ToString());
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + apiRequest.AccessToken);
                
                var message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.RelativeUrl,UriKind.Relative);
                //client.DefaultRequestHeaders.Clear();              
                if (apiRequest.Data != null)
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data),
                            Encoding.UTF8, "application/json");

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
                
                if(apiResponse != null && 
                    apiResponse.IsSuccessStatusCode &&
                    apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var apiContent = await apiResponse.Content.ReadAsStringAsync();
                    var apiResponseDto = JsonConvert.DeserializeObject<Tout>(apiContent);
                    return apiResponseDto;
                }
                else
                {
                    var response = new ResponseDto();
                    response.IsSuccess = false;
                    if (apiResponse != null)
                        response.ErrorMessages = new List<string> {apiResponse.ReasonPhrase};
                    else
                        response.ErrorMessages = new List<string> { "undefined error"};

                    return JsonConvert.DeserializeObject<Tout>(JsonConvert.SerializeObject(response));
                }          
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
