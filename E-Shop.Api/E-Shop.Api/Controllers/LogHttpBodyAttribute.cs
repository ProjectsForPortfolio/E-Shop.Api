using System;
using log4net;
using Microsoft.AspNetCore.Mvc.Filters;

namespace E_Shop.Api.Controllers
{
    [AttributeUsage(AttributeTargets.Method)]
    public class LogHttpBodyAttribute : ActionFilterAttribute
    {
        private readonly ILog logger = LogManager.GetLogger(typeof(LogHttpBodyAttribute));
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            logger.Debug($"Received a call to {string.Join("/",context.RouteData.Values)} with request {string.Join(", ",context.HttpContext.Request.Headers)}");
        }
    }
}
