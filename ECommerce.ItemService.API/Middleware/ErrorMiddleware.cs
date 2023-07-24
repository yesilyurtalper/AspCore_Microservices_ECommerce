
using ECommerce.ItemService.API.Constants;
using ECommerce.ItemService.API.Models;
using ECommerce.ItemService.Application.DTOs;
using ECommerce.ItemService.Application.Exceptions;
using Serilog;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace ECommerce.ItemService.Api.Middleware;

public class ErrorMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        await _next(httpContext);
        var statusCode = httpContext.Response.StatusCode;

        if (!APIConstants.KnownCodes.Contains(statusCode))
        {
            var desc = APIConstants.StatusDescriptions.TryGetValue(statusCode, out var message);
            if (!desc)
                message = statusCode.ToString();
            ResponseDto<string> problem = new()
            {
                ResultCode = statusCode.ToString(),
                IsSuccess = false,
                Message = desc == true ? message : message,
                ErrorMessages = new List<string> {message}
            };

            var log = new CustomLog
            {
                Method = httpContext.Request.Method,
                Path = httpContext.Request.Path.Value,
                Result = problem,
                User = httpContext.User.Claims.FirstOrDefault(c => c.Type == "preferred_username")?.Value
            };
            Log.Error("{@log}", log);

            await httpContext.Response.WriteAsJsonAsync(problem);
        }
    }
}
