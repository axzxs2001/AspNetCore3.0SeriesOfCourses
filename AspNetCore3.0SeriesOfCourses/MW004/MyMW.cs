using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MW004
{
    public class MyMW
    {
        private readonly RequestDelegate _next;
        public MyMW(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            //context.Request
            await context.Response.WriteAsync("user error");
            //await _next(context);

        }
    }

    public static class MyMWExtensions
    {
        public static IApplicationBuilder UserMyMW(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyMW>();
        }
    }
}
