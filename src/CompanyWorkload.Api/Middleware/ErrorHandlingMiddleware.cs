using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CompanyWorkload.Api.Middleware;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ProblemDetailsFactory _problemDetailsFactory;
    private readonly ILogger<ErrorHandlingMiddleware> _logger;

    public ErrorHandlingMiddleware(
        RequestDelegate next,
        ProblemDetailsFactory problemDetailsFactory,
        ILogger<ErrorHandlingMiddleware> logger)
    {
        _next = next;
        _problemDetailsFactory = problemDetailsFactory;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception");

            var problem = _problemDetailsFactory.CreateProblemDetails(
                context,
                statusCode: (int)HttpStatusCode.InternalServerError,
                title: "Внутренняя ошибка сервера",
                detail: ex.Message);

            context.Response.StatusCode = problem.Status ?? (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/problem+json";

            await context.Response.WriteAsJsonAsync(problem);
        }
    }
}

public static class ErrorHandlingMiddlewareExtensions
{
    public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder app) =>
        app.UseMiddleware<ErrorHandlingMiddleware>();
}
