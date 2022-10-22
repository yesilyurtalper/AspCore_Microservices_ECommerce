using ECommerce.Web.Models;

namespace ECommerce.Web.Services
{
    public interface IBaseService : IDisposable
    {
        public ResponseDto responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
