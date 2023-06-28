//using MediatR;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ECommerce.ItemService.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this  IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddFluentValidationAutoValidation(options =>
        {
            options.DisableDataAnnotationsValidation = true;
        });
        services.AddMediatR(options =>
        {
            options.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
        });

        return services;
    }
}
