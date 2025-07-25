﻿using System.Net;
using System.Text.Json;
using TechChallenge.Domain.Entities.Base;
using TechChallenge.Infra.Exceptions;
using TechChallenge.Infra.Responses;

namespace TechChallenge.API.Middlewares;

public class ApiErrorMiddleware(RequestDelegate next, ILogger<ApiErrorMiddleware> logger)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<ApiErrorMiddleware> _logger = logger;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        _logger.LogError(exception, "Erro: {Message}", exception.Message);

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = StatusCodes.Status400BadRequest; // Sempre vai ser 400

        if (exception is ApiTechChallengeException techChallengeException)
        {
            var response = ResponseBase<IEntity>.Error(techChallengeException.StatusCode, techChallengeException.Errors);
            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
        else
        {
            var response = ResponseBase<IEntity>.Error(HttpStatusCode.InternalServerError, ["Erro interno"]);
            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
