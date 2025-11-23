using ConnectA.Domain.Exceptions;
using Microsoft.Extensions.Logging;

namespace ConnectA.API.Middleware;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlingMiddleware> _logger;

    public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception while processing request {Method} {Path}", context.Request.Method, context.Request.Path);
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        int statusCode;
        var message = exception.Message;
        
        switch (exception)
        {
            case UserAlreadyExistsException or ProfileAlreadyExistsException:
                statusCode = StatusCodes.Status409Conflict;
                break;

            case ArgumentException:
                statusCode = StatusCodes.Status400BadRequest;
                break;
            
            case UserNotFoundException:
                statusCode = StatusCodes.Status404NotFound;
                break;
            
            case UnauthorizedAccessException:
                statusCode = StatusCodes.Status401Unauthorized;
                break;

            default:
                statusCode = StatusCodes.Status500InternalServerError;
                message = "An unexpected error occurred.";
                break;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;

        return context.Response.WriteAsJsonAsync(new
        {
            error = message,
            status = statusCode
        });
    }
}