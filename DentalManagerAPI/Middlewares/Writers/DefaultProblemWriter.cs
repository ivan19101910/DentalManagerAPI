using Microsoft.AspNetCore.Mvc;

namespace DentalManager.Api.Middlewares.Writers;

public sealed class DefaultProblemWriter : IProblemWriter
{
    private readonly IConfiguration _configuration;

    public DefaultProblemWriter(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public ProblemDetails Write(HttpContext httpContext, Exception exception)
    {
        var statusCode = exception switch
        {
            ArgumentException => StatusCodes.Status400BadRequest,
            UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
            NotImplementedException => StatusCodes.Status501NotImplemented,
            FormatException => StatusCodes.Status400BadRequest,
            HttpRequestException => StatusCodes.Status409Conflict,
            InvalidOperationException => StatusCodes.Status400BadRequest,
            _ => StatusCodes.Status500InternalServerError,
        };

        var exceptionHandling = _configuration.GetSection("ExceptionHandling");

        var useErrorMessageInResponse = exceptionHandling.GetValue<bool>("UseDebugErrorHandling");

        if (useErrorMessageInResponse)
        {
            return new ProblemDetails
            {
                Instance = httpContext.Request.Path,
                Status = statusCode,
                Title = exception.Message,
            };
        }

        if (httpContext.Response.StatusCode >= StatusCodes.Status500InternalServerError)
        {
            return new ProblemDetails
            {
                Instance = httpContext.Request.Path,
                Status = statusCode,
                Title = exceptionHandling.GetValue<string>("InternalServerError") ?? "Internal error.",
            };
        }

        return new ProblemDetails
        {
            Instance = httpContext.Request.Path,
            Status = statusCode,
            Title = exceptionHandling.GetValue<string>("InvalidRequestError") ?? "Invalid request error."
        };
    }
}
