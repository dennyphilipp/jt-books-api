using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;

namespace book_api.Infrastructure.Exception
{
    internal sealed class ExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, System.Exception exception, CancellationToken cancellationToken)
        {
            int code = StatusCodes.Status500InternalServerError;
            if (exception is NotFoundException notFoundException)
                code = StatusCodes.Status404NotFound;

            var result = new { Message = exception.Message };
            httpContext.Response.StatusCode = code;

            await httpContext.Response
            .WriteAsJsonAsync(result, cancellationToken);

            return true;
        }
    }
}