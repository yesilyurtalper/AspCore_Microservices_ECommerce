using ECommer.ItemUI.Models;

namespace ECommer.ItemUI.Services
{
    public interface IBaseService : IDisposable
    {
        public ResponseDto responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
