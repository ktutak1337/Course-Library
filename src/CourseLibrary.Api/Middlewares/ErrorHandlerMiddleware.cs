using System;
using System.Net;
using System.Threading.Tasks;
using CourseLibrary.Core.Exceptions;
using CourseLibrary.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ApplicationException = CourseLibrary.Application.Exceptions.ApplicationException;

namespace CourseLibrary.Api.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        public ErrorHandlerMiddleware(RequestDelegate next, ILoggerFactory loggerFactory) 
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
             _logger = loggerFactory?.CreateLogger<ErrorHandlerMiddleware>() ?? throw new ArgumentNullException(nameof(loggerFactory));
        }
            
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                await HandleErrorAsync(context, exception);
            }
        }

        private async static Task HandleErrorAsync(HttpContext context, Exception exception)
        {
            var errorCode = "Error";
            var message = exception.Message;
            var statusCode = 400;

            (errorCode, message) = exception switch
            {
                InfrastructureException ex => (ex.Code, ex.Message),
                ApplicationException ex => (ex.Code, ex.Message),
                DomainException ex => (ex.Code, ex.Message),
                _ => ("Error", "There was an error.")
            };

            context.Response.StatusCode = (int)statusCode;
            await context.Response.WriteAsJsonAsync(new {errorCode, message});
        }
    }
}
