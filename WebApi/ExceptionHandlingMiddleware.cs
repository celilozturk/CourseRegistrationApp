﻿
using Application.Exceptions;
using Domain.Common.Exceptions;
using System.Text.Json;

namespace WebApi;

public   class ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            logger.LogError(e, e.Message);

            await HandleExceptionAsync(context, e);
        }
    }
    private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        httpContext.Response.ContentType = "application/json";

        httpContext.Response.StatusCode = exception switch
        {
            BadRequestException or ValidationException => StatusCodes.Status400BadRequest,
            NotFoundException => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };

        var errors = Array.Empty<ApiError>();

        if (exception is ValidationException validationException)
        {
            errors = validationException.Errors
                .SelectMany(
                    kvp => kvp.Value,
                    (kvp, value) => new ApiError(kvp.Key, value))
                .ToArray();
        }

        var response = new
        {
            status = httpContext.Response.StatusCode,
            message = exception.Message,
            errors
        };

        await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
    private record ApiError(string PropertyName, string ErrorMessage);
}
