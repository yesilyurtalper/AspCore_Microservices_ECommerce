
using ECommerce.ItemService.API.Models;
using ECommerce.ItemService.Application.DTOs;
using ECommerce.ItemService.Application.Exceptions;
using Serilog;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace ECommerce.ItemService.Api.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
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

        var log = new CustomLog
        {
            Method = httpContext.Request.Method,
            Path = httpContext.Request.Path.Value,
            Result = problem,
            User = httpContext.User.Claims.FirstOrDefault(c => c.Type == "preferred_username")?.Value,
        };
        Log.Error("{@log}",log);

        await httpContext.Response.WriteAsJsonAsync(problem);
    }
}
