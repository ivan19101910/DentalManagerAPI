using Microsoft.AspNetCore.Diagnostics;

namespace DentalManager.Api.Middlewares;

public sealed class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    private readonly IProblemWriter _problemDetailsWriter;

    private readonly IProblemDetailsService _problemDetailsService;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger, IProblemWriter problemDetailsWriter, IProblemDetailsService problemDetailsService)
    {
        _logger = logger;
        _problemDetailsWriter = problemDetailsWriter;
        _problemDetailsService = problemDetailsService;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var problemDetails = _problemDetailsWriter.Write(httpContext, exception);

        _logger.LogError(exception, "{ExceptionType} handled with satus {StatusCode}. Message: {Message}", exception.GetType().Name, problemDetails.Status, exception.Message);

        var inner = exception.InnerException;

        while (inner is not null)
        {
            _logger.LogError(inner, "Inner exception {ExceptionType}. Message: {Message}", inner.GetType().Name, inner.Message);
            inner = inner.InnerException;
        }

        httpContext.Response.StatusCode = problemDetails.Status.GetValueOrDefault();

        var handledByProblemDetails = await _problemDetailsService.TryWriteAsync(new ProblemDetailsContext
        {
            HttpContext = httpContext,
            ProblemDetails = problemDetails
        });

        if (!handledByProblemDetails)
        {
            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
        }

        return true;
    }
}
