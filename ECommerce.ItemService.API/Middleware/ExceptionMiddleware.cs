
using ECommerce.ItemService.Application.DTOs;
using ECommerce.ItemService.Application.Exceptions;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace ECommerce.ItemService.Api.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
    {
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
        ResponseDto<string> problem = new();

        switch (ex)
        {
            case BadRequestException:
                statusCode = HttpStatusCode.BadRequest;
                break;
            case NotFoundException:
                statusCode = HttpStatusCode.NotFound;
                break;
        }

        httpContext.Response.StatusCode = (int)statusCode;
        problem.ResultCode = httpContext.Response.StatusCode.ToString();
        problem.ErrorMessages = new List<string> { ex.ToString() };
        problem.Message = ex.Message;
        var logMessage = JsonSerializer.Serialize(problem);
        _logger.LogError(logMessage);
        await httpContext.Response.WriteAsJsonAsync(problem);
    }
}
