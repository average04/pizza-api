namespace Pizza.Application.Behavior;

public class LoggingBehavior<TRequest, TResponse>()
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull, IRequest<TResponse>
    where TResponse : notnull
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        Log.Information("[START] Handle request={Request} - Response={Response} - RequestData={RequestData}",
            typeof(TRequest).Name, typeof(TResponse).Name, request);

        var timer = new Stopwatch();
        timer.Start();

        var response = await next();

        timer.Stop();
        var timeTaken = timer.Elapsed;
        if (timeTaken.Seconds > 3) // if the request is greater than 3 seconds, then log the warnings
            Log.Warning("[PERFORMANCE] The request {Request} took {TimeTaken} seconds.",
                typeof(TRequest).Name, timeTaken.TotalSeconds);

        Log.Information("[END] Handled {Request} with {Response}", typeof(TRequest).Name, typeof(TResponse).Name);
        return response;
    }
}
