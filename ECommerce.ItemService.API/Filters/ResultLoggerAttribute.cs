using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using ECommerce.ItemService.Application.DTOs;
using Serilog;

namespace ECommerce.ItemService.API.Filters;

[AttributeUsage(AttributeTargets.Method)]
public class ResultLoggerAttribute : Attribute, IAsyncResultFilter
{
    
    public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = (ResponseDtoBase)((context.Result as ObjectResult).Value);
        if (result.IsSuccess)
        {
            result.ResultCode = context.HttpContext.Response.StatusCode.ToString();
            var user = context.HttpContext.User.Claims.
                    FirstOrDefault(c => c.Type == "preferred_username").Value;
            var log = new
            {
                method = context.HttpContext.Request.Method,
                path = context.HttpContext.Request.Path.Value,
                result,
                user
            };

            Log.Information("{@result}",log);
        }
        
        await next();
    }
}

