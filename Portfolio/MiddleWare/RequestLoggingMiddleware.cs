namespace Portfolio.MiddleWare;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public RequestLoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
    {
        _next = next;
        _logger = loggerFactory.CreateLogger<RequestLoggingMiddleware>();
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        finally
        {
            _logger.LogInformation(
                "Request {method} {url} => {statusCode} \r\n" +
                "Body: {body} \r\n" +
                "Headers: {headers} \r\n",
                context.Request?.Method,
                context.Request?.Path.Value,
                context.Response?.StatusCode, context.Response?.Body, context.Response?.Headers);
        }
    }
}

public static class LoggingRequestMiddlewareExtensions
{
    public static IApplicationBuilder UseRequestLogs(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RequestLoggingMiddleware>();
    }
}

