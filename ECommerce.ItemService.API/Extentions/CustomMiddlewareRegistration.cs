using ECommerce.ItemService.Api.Middleware;

namespace ECommerce.ItemService.API.Extentions;

public static class CustomMiddlewareRegistration
{
    public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
    {
        builder.UseMiddleware<ExceptionMiddleware>();
        return builder;
    }

    public static IApplicationBuilder UseErrorMiddleware(this IApplicationBuilder builder)
    {
        builder.UseMiddleware<ErrorMiddleware>();
        return builder;
    }
}
