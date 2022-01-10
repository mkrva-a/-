using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using laba1.Services;

namespace laba1
{
    public class CounterMiddleware
    {
        private readonly RequestDelegate _next;

        public CounterMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, ICounter stringAddertor)
        {
            await httpContext.Response.WriteAsync($"Count: {stringAddertor.Value} ");
            await _next(httpContext);
        }
    }
}
