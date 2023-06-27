
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Domain;
using ECommerce.ItemService.Infra.DBContext;
using ECommerce.ItemService.Infra.Services.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.ItemService.Infra;

public static class InfrasServiceRegistration
{
    public static IServiceCollection AddInfraServices(this  IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

        //string conStr = "server=localhost;port=3306;database=ECommerceItemAPI;user=root;password=pass;";
        string conStr = configuration.GetConnectionString("DefaultConnection");
        //string conStr = Environment.GetEnvironmentVariable("DB_CON_STR");
        services.AddDbContext<ItemAPIDbContext>(options => options.UseMySQL(conStr));

        services.AddScoped<ICategoryRepository, DBCategoryRepository>();
        services.AddScoped<IBrandRepository, DBBrandRepository>();
        services.AddScoped<IProductRepository, DBProductRepository>();

        return services;
    }
}
