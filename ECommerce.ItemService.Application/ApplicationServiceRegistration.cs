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

        //var builder = new ContainerBuilder();
        //builder.RegisterGeneric(typeof(IRequestHandler<,>)).AsImplementedInterfaces();

        //services.AddTransient(typeof(IRequestHandler<Category,BaseDto>), typeof(CreateBaseItemCommandHandler<,>));

            //services.AddTransient<
            //    IRequestHandler<CreateBaseItemCommand<BaseDto>, ResponseDto>,
            //    CreateBaseItemCommandHandler<BaseItem, BaseDto>
            //    >();

        //No service for type 'MediatR.IRequestHandler`2[ECommerce.ItemService.Application.CQRS.BaseItem.Commands.CreateBaseItemCommand`1[ECommerce.ItemService.Application.DTOs.BaseDto],ECommerce.ItemService.Application.DTOs.ResponseDto]' has been registered.
        return services;
    }
}
