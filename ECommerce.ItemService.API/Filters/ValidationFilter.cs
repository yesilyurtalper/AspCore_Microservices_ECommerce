using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using ECommerce.ItemService.Application.DTOs;

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

            ResponseDto<string> responseDto = new()
            {
                Message = "There are errors in the request",
                ResultCode = "400",
            }; 
            
            List<string> errors = new ();
            foreach (var error in errorsInModelState)
                foreach (var subError in error.Value)
                    errors.Add(error.Key + " - " + subError);
            responseDto.ErrorMessages = errors;

            context.Result = new BadRequestObjectResult(responseDto);
        }

        await next();
    }
}

