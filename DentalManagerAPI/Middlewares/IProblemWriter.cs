using Microsoft.AspNetCore.Mvc;

namespace DentalManager.Api.Middlewares;

public interface IProblemWriter
{
    ProblemDetails Write(HttpContext httpContext, Exception exception);
}
