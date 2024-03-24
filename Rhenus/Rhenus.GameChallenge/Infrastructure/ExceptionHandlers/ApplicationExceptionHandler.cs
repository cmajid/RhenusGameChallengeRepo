
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Rhenus.GameChallenge.Infrastructure.ExceptionHandlers;

internal sealed class ApplicationExceptionHandler(ILogger<ApplicationExceptionHandler> logger) 
    : IExceptionHandler
{

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        if (exception is not ApplicationException applicationException)
        {
            return false;
        }

        logger.LogError(
            applicationException,
            "Exception occurred: {Message}",
            applicationException.Message);

        var problemDetails = new ProblemDetails
        {
            Status = StatusCodes.Status400BadRequest,
            Title = "Bad Request",
            Detail = applicationException.Message
        };

        httpContext.Response.StatusCode = problemDetails.Status.Value;

        await httpContext.Response
            .WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }
}