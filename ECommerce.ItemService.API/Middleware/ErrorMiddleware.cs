
using ECommerce.ItemService.API.Constants;
using ECommerce.ItemService.Application.DTOs;
using ECommerce.ItemService.Application.Exceptions;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace ECommerce.ItemService.Api.Middleware;

public class ErrorMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorMiddleware> _logger;

    public ErrorMiddleware(RequestDelegate next, ILogger<ErrorMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        await _next(httpContext);
        var statusCode = httpContext.Response.StatusCode;

        if (!APIConstants.KnownCodes.Contains(statusCode))
        {
            ResponseDto<string> problem = new()
            {
                ResultCode = statusCode.ToString(),
                IsSuccess = false,
                Message = statusCode.ToString(),
                ErrorMessages = new List<string> {statusCode.ToString()}
            };

            _logger.LogError("{@problem}", problem);
            await httpContext.Response.WriteAsJsonAsync(problem);
        }
    }
}
