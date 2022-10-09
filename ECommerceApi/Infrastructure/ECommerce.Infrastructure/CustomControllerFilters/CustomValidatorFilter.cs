using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ECommerce.Infrastructure.CustomControllerFilters
{
    public class CustomValidatorFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Where(i => i.Value.Errors.Any())
                    .ToDictionary(e => e.Key, x => x.Value.Errors.Select(i => i.ErrorMessage)).ToArray();
                context.Result = new BadRequestObjectResult(errors);
                return;
            }

            await next();
        }
    }
}
