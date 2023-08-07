using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace ECommerce.ItemService.Infrastructure.HttpHandlers
{
    public class AuthHeaderHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public AuthHeaderHandler(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var access_token = await _contextAccessor.HttpContext.GetTokenAsync("access_token");
            request.Headers.Add("Authorization", $"Bearer {access_token}");
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
