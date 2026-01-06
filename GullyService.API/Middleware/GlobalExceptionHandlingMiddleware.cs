using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace GullyService.API.Middleware
{
    public class GlobalExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;
        private readonly IHostEnvironment _environment;

        public GlobalExceptionHandlingMiddleware(
            RequestDelegate next,
            ILogger<GlobalExceptionHandlingMiddleware> logger,
            IHostEnvironment environment)
        {
            _next = next;
            _logger = logger;
            _environment = environment;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception occurred");

                await WriteProblemDetailsResponse(context, ex);
            }
        }

        private async Task WriteProblemDetailsResponse(HttpContext context, Exception exception)
        {
            var statusCode = HttpStatusCode.InternalServerError;

            var problemDetails = new ProblemDetails
            {
                Status = (int)statusCode,
                Title = "An unexpected error occurred",
                Detail = _environment.IsDevelopment()
                    ? exception.Message
                    : "An internal server error occurred",
                Instance = context.Request.Path
            };

            context.Response.Clear();
            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = "application/problem+json";

            var json = JsonSerializer.Serialize(problemDetails);

            await context.Response.WriteAsync(json);
        }
    }
}
