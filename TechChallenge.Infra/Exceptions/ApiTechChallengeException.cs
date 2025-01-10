using System.Net;

namespace TechChallenge.Infra.Exceptions;
public class ApiTechChallengeException(HttpStatusCode statusCode, List<string> errors) : Exception(errors[0])
{
    public List<string> Errors { get; set; } = errors;
    public HttpStatusCode StatusCode { get; set; } = statusCode;
}
