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

            Log.Information("{method} {path} with result: {@result}",
                context.HttpContext.Request.Method, context.HttpContext.Request.Path, result);
        }
        
        await next();
    }
}

