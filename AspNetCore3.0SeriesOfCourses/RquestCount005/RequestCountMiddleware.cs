using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RquestCount005
{
    public class RequestCountMiddleware
    {
        private readonly RequestDelegate _next;
        public RequestCountMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context, IRequestCountService requestCountService)
        {
            requestCountService.RequestList.Add(context.TraceIdentifier, true);
            await _next(context);
            requestCountService.RequestList[context.TraceIdentifier] = false;

        }
    }

    public static class RequestCountMiddlewareExtionsions
    {
        public static IApplicationBuilder UseRequestCount(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestCountMiddleware>();
        }
    }
}
