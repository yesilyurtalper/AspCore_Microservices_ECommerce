
using Microsoft.IdentityModel.Tokens;

namespace ECommerce.ItemService.API.Extensions;

public static class AuthServiceRegistration
{
    public static IServiceCollection AddAuthServices(this  IServiceCollection services)
    {
        services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options =>
        {
            options.Authority = Environment.GetEnvironmentVariable("OIDC_AUTHORITY");
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidAudiences = new[] { "ECommerce_ItemAPI", "ECommerceWebClient_AspMvc" },
                ValidateIssuer = true,
                ValidIssuers = new List<string> { 
                    "http://localhost:8080/auth/realms/local_realm",
                    Environment.GetEnvironmentVariable("OIDC_AUTHORITY")
        }
            };
        });

        services.AddAuthorization(options =>
        {
            options.AddPolicy("ECommerceWebClient", policy =>
            {
                policy.RequireClaim("ECommerceWebClient", "ECommerceWebClient");
            });
        });

        services.AddAuthorization(options =>
        {
            options.AddPolicy("ECommerceAdmin", policy =>
            {
                policy.RequireClaim("RealmRole", "ECommerceAdmin");
            });
        });

        return services;
    }
}
