using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using laba1.Services;

namespace laba1
{
    public class AnotherStringMiddleware
    {
        private readonly RequestDelegate _next;

        public AnotherStringMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, IAnotherString stringAddertor)
        {
            await httpContext.Response.WriteAsync($"Another string: {stringAddertor.String} ");
            await _next(httpContext);
        }
    }
}
