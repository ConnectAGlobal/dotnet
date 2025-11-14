using ConnectA.Domain.Exceptions;

namespace ConnectA.API.Middleware;

public class ErrorHandlingMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        int statusCode;
        var message = exception.Message;
        
        switch (exception)
        {
            case UserAlreadyExistsException:
                statusCode = StatusCodes.Status409Conflict;
                break;

            case ArgumentException:
                statusCode = StatusCodes.Status400BadRequest;
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