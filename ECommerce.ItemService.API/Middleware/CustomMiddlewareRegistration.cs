using ECommerce.ItemService.Api.Middleware;

namespace ECommerce.ItemService.API.Middleware
{
    public static class CustomMiddlewareRegistration
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<ExceptionMiddleware>();
            return builder;
        }
    }
}
