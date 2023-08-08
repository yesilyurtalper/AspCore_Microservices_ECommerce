
using ECommerce.ItemService.Application.Contracts;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Domain;
using ECommerce.ItemService.Infra.DBContext;
using ECommerce.ItemService.Infra.Services.Persistence;
using ECommerce.ItemService.Infrastructure.Constants;
using ECommerce.ItemService.Infrastructure.HttpHandlers;
using ECommerce.ItemService.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;

namespace ECommerce.ItemService.Infra;

public static class InfraServiceRegistration
{
    public static IServiceCollection AddInfraServices(this  IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

        //string conStr = "server=localhost;port=3306;database=ECommerceItemAPI;user=root;password=pass;";
        //string conStr = configuration.GetConnectionString("DefaultConnection");
        string conStr = Environment.GetEnvironmentVariable("DB_CON_STR");
        services.AddDbContext<ItemAPIDbContext>(options => options.UseMySQL(conStr));

        services.AddScoped<ICategoryRepo, DBCategoryRepo>();
        services.AddScoped<IBrandRepo, DBBrandRepo>();
        services.AddScoped<IProductRepo, DBProductRepo>();

        services.AddTransient<AuthHeaderHandler>();

        services.AddScoped<IOrderService, OrderService>();
        services.AddHttpClient(InfraConstants.OrderAPIClient, options =>
        {
            options.BaseAddress = new Uri(InfraConstants.OrderAPIBaseUrl);
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
