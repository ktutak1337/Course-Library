using CourseLibrary.Api.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace CourseLibrary.Api
{
    public static class Extensions
    {
        public static IApplicationBuilder UseErrorHandler(this IApplicationBuilder builder)
            => builder.UseMiddleware(typeof(ErrorHandlerMiddleware));
    }
}
