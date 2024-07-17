using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Behaviors.Logging;
public class LoggingBehavior<TRequest, TResponse> (ILogger<LoggingBehavior<TRequest,TResponse>> logger): IPipelineBehavior<TRequest, TResponse>
{

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Handling {typeof(TRequest).Name}");

        var response = await next();
        logger.LogInformation($"Handled {typeof(TResponse).Name}");

        return response;

    }
}
