namespace Pizza.API.ExceptionHandler;

public class CustomExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext context, Exception exception, CancellationToken cancellationToken)
    {
        (string Detail, string Title, int StatusCode) details = exception switch
        {
            ValidationException =>
            (
                exception.Message,
                exception.GetType().Name,
                context.Response.StatusCode = StatusCodes.Status400BadRequest
            ),
            BadRequestException =>
            (
                exception.Message,
                exception.GetType().Name,
                context.Response.StatusCode = StatusCodes.Status400BadRequest
            ),
            NotFoundException =>
            (
                exception.Message,
                exception.GetType().Name,
                context.Response.StatusCode = StatusCodes.Status404NotFound
            ),
            _ =>
            (
                exception.Message,
                exception.GetType().Name,
                context.Response.StatusCode = StatusCodes.Status500InternalServerError
            )
        };

        var problemDetails = new ProblemDetails
        {
            Title = details.Title,
            Detail = details.Detail,
            Status = details.StatusCode,
            Instance = context.Request.Path
        };

        problemDetails.Extensions.Add("traceId", context.TraceIdentifier);

        if (exception is ValidationException validationException)
        {
            problemDetails.Extensions.Add("ValidationErrors", validationException.Errors);

            Log.Error(exception, "Bad request information {RequestMethod} {RequestPath} {statusCode}", context.Request.Method, context.Request.Path, context.Response.StatusCode);
        }
        else if (exception is NotFoundException)
            Log.Error(exception, "Not found request information {RequestMethod} {RequestPath} {statusCode}", context.Request.Method, context.Request.Path, context.Response.StatusCode);
        else if (exception is BadRequestException)
            Log.Error(exception, "Bad request information {RequestMethod} {RequestPath} {statusCode}", context.Request.Method, context.Request.Path, context.Response.StatusCode);
        else
            Log.Fatal(exception, "Unhandled exception information {RequestMethod} {RequestPath} {statusCode}", context.Request.Method, context.Request.Path, context.Response.StatusCode);

        await context.Response.WriteAsJsonAsync(problemDetails, cancellationToken: cancellationToken);
        return true;
    }
}
