
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Infra.DBContext;
using ECommerce.ItemService.Infra.Services.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.ItemService.Infra;

public static class InfrasServiceRegistration
{
    public static IServiceCollection AddInfraServices(this  IServiceCollection services)
    {

        //string conStr = "server=localhost;port=3306;database=ECommerceItemAPI;user=root;password=mysecretpassword;";
        //string conStr = builder.Configuration.GetConnectionString("DefaultConnection");
        string conStr = Environment.GetEnvironmentVariable("DB_CON_STR");
        services.AddDbContext<ItemAPIDbContext>(options => options.UseMySQL(conStr));

        services.AddScoped<ICategoryRepository, DBCategoryRepository>();
        services.AddScoped<IBrandRepository, DBBrandRepository>();
        services.AddScoped<IProductRepository, DBProductRepository>();

        return services;
    }
}
