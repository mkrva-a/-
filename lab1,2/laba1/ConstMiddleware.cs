using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using laba1.Services;

namespace laba1
{
    public class ConstMiddleware
    {
        private readonly RequestDelegate _next;

        public ConstMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext, ConstService constService)
        {
            await httpContext.Response.WriteAsync($"Const: {constService.Value} ");
            await _next(httpContext);
        }
    }
}
