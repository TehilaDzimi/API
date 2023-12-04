using Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Repository;
using System.Threading.Tasks;

namespace API
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Middleware
    {
        IRatingService _RatingService;
        private readonly RequestDelegate _next;

        public Middleware(RequestDelegate next)
        {
            _next = next;
            
        }
        public async Task Invoke(HttpContext httpContext, IRatingService ratingService)
        {
            Rating rate = new Rating
            {
                Host = httpContext.Request.Host.ToString(),
                Method = httpContext.Request.Method.ToString(),
                Path = httpContext.Request.Path.ToString(),
                Referer = httpContext.Request.Path.ToString(),
                UserAgent = httpContext.User.ToString(),
                RecordDate = DateTime.Now,
            };
            await ratingService.addRating(rate);
           
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware>();
        }
    }
}
