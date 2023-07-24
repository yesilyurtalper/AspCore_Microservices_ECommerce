using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using ECommerce.ItemService.Application.DTOs;
using Serilog;
using ECommerce.ItemService.API.Models;
using Microsoft.AspNetCore.Http;

namespace ECommerce.ItemService.API.Filters;

public class ValidationFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.ModelState.IsValid)
        {
            var errorsInModelState = context.ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(x => x.ErrorMessage)).ToArray();

            ResponseDto<string> problem = new()
            {
                Message = "There are errors in the request",
                ResultCode = "400",
            }; 
            
            List<string> errors = new ();
            foreach (var error in errorsInModelState)
                foreach (var subError in error.Value)
                    errors.Add(error.Key + " - " + subError);
            problem.ErrorMessages = errors;

            var log = new CustomLog
            {
                Method = context.HttpContext.Request.Method,
                Path = context.HttpContext.Request.Path.Value,
                Result = problem,
                User = context.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "preferred_username")?.Value,
            };
            Log.Error("{@log}", log);

            context.Result = new BadRequestObjectResult(problem);
        }
        else
            await next();
    }
}

