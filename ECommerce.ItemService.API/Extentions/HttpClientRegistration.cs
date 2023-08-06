using ECommerce.ItemService.API.Constants;
using ECommerce.ItemService.API.HttpHandlers;
using Polly;

namespace ECommerce.ItemService.API.Extentions
{
    public static class HttpClientRegistration
    {
        public static IServiceCollection AddHttpClients(this IServiceCollection services)
        {
            services.AddTransient<AuthHeaderHandler>();
            services.AddHttpClient(APIConstants.OrderAPIClient, options =>
            {
                options.BaseAddress = new Uri(APIConstants.OrderAPIBaseUrl);
            })
                .AddHttpMessageHandler<AuthHeaderHandler>()
                .AddTransientHttpErrorPolicy(policyBuilder =>
                    policyBuilder.WaitAndRetryAsync(3, retryNumber => TimeSpan.FromSeconds(5)))
                .AddPolicyHandler(Policy.TimeoutAsync(15).AsAsyncPolicy<HttpResponseMessage>())
                .AddTransientHttpErrorPolicy(policyBuilder =>
                    policyBuilder.CircuitBreakerAsync(5, TimeSpan.FromSeconds(20)));

            return services;
        }
    }
}
