using Serilog.Context;

namespace ECommerce.Api.Middlewares
{
    public class SerilogUsernameMiddleware
    {
        private readonly RequestDelegate next;

        public SerilogUsernameMiddleware(RequestDelegate next)
        
        {
            this.next = next;
        }

        public Task Invoke(HttpContext context)
        {
            if (context.User?.Identity?.IsAuthenticated ?? false)
            {
                LogContext.PushProperty("UserName", context.User.Identity.Name);
            }
            return next(context);
        }
    }
}
