using System.Net;
using System.Text.Json;
using TechChallenge.Domain.Entities.Base;
using TechChallenge.Infra.Exceptions;
using TechChallenge.Infra.Responses;

namespace TechChallenge.API.Middlewares;

public class ApiErrorMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

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

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
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
