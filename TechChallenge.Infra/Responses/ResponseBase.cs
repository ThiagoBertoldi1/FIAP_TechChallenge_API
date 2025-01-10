using System.Net;

namespace TechChallenge.Infra.Responses;

public class ResponseBase<T>
{
    public T? Data { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public List<string> Errors { get; set; }

    private ResponseBase(T? data)
    {
        Data = data;
        StatusCode = HttpStatusCode.OK;
        Errors = [];
    }

    private ResponseBase(HttpStatusCode httpStatusCode, List<string> errors)
    {
        Data = default;
        StatusCode = httpStatusCode;
        Errors = errors;
    }

    public static ResponseBase<T> Create(T? data) => new(data);
    public static ResponseBase<T> Fault(HttpStatusCode httpStatusCode, List<string> errors) => new(httpStatusCode, errors);
}
