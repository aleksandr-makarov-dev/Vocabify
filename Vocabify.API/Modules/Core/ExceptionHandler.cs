using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Vocabify.API.Modules.Core.Exceptions;

namespace Vocabify.API.Modules.Core
{
    public class ExceptionHandler:IExceptionHandler
    {
        private readonly ILogger<ExceptionHandler> _logger;

        public ExceptionHandler(ILogger<ExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogError(exception,$"Exception occured: {exception.Message}");

            ProblemDetails problemDetails = new ProblemDetails();

            switch (exception)
            {
                case NotFoundException:
                    problemDetails.Title = "Not found";
                    problemDetails.Status = StatusCodes.Status404NotFound;
                    break;

                case BadRequestException:
                    problemDetails.Title = "Bad request";
                    problemDetails.Status = StatusCodes.Status400BadRequest;
                    break;

                case UnauthorizedException:
                    problemDetails.Title = "Unauthorized";
                    problemDetails.Status = StatusCodes.Status401Unauthorized;
                    break;

                default:
                    problemDetails.Title = "Server error";
                    problemDetails.Status = StatusCodes.Status500InternalServerError;
                    break;
            };  

            problemDetails.Detail = exception.Message;

            httpContext.Response.StatusCode = problemDetails.Status.Value;

            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }
    }
}
