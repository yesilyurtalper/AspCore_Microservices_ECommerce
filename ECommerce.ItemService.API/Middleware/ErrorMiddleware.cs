
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
    private readonly ILogger<ErrorMiddleware> _logger;

    public ErrorMiddleware(RequestDelegate next,ILogger<ErrorMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        await _next(httpContext);
        var statusCode = httpContext.Response.StatusCode;

        if (!APIConstants.KnownCodes.Contains(statusCode) 
            && statusCode.ToString().StartsWith("4"))
        {
            var desc = APIConstants.StatusDescriptions.TryGetValue(statusCode, out var message);
            if (!desc)
                message = statusCode.ToString();
            ResponseDto<string> problem = new()
            {
                ResultCode = statusCode.ToString(),
                IsSuccess = false,
                Message = message,
                ErrorMessages = new List<string> {message}
            };

            _logger.LogError("{@problem}", problem);

            await httpContext.Response.WriteAsJsonAsync(problem);
        }
    }
}
